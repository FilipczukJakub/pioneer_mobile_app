using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PracaInzynierska.CustomElements;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Threading;
using System.Text;
using System.Runtime.CompilerServices;
using System.Net.Sockets;
using System.Net;
using Xamarin.Essentials;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms.Shapes;
using TouchTracking;
using TouchTracking.Forms;
using System.Drawing;
using PracaInzynierska.Models;
using System.Collections;
namespace PracaInzynierska.Views
{
    public sealed partial class AboutPage : ContentPage
    {
        public static ClientWebSocket Client;
        private static AboutPage _instance;
        private bool _popUpVisible = false;
        private double joystickWidth;
        private double joystickHeight;
        private double maxSpeed = 1.0;
        private Thread pong_thread;
        public static AboutPage GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AboutPage();
            }
            return _instance;
        }
        public AboutPage()
        {
            InitializeComponent();
            GetConnection();
            speedLabel.Text = "Prędkość: " + maxSpeed;

        }


        public async void GetConnection()
        {
            try
            {
                int PORT = 12345;
                UdpClient udpClient = new UdpClient();
                udpClient.EnableBroadcast = true;
                IPEndPoint broadcast_ip = new IPEndPoint(IPAddress.Parse("255.255.255.255"), PORT);
                IPEndPoint any_ip = new IPEndPoint(IPAddress.Any, 0);
                var data = Encoding.ASCII.GetBytes("ip_request");
                udpClient.Send(data, data.Length, broadcast_ip);
                udpClient.Client.ReceiveTimeout = 2000;
                byte[] bytes = udpClient.Receive(ref any_ip);
                string message = Encoding.ASCII.GetString(bytes);
                Uri serverUri = new Uri($"ws://{message}:8765");
                var client = new ClientWebSocket();
                await client.ConnectAsync(serverUri, CancellationToken.None);
                Client = client;
                pong_thread = new Thread(new ThreadStart(Ping));
                pong_thread.Start();
            }
            catch (Exception ex)
            {
                if (!_popUpVisible)
                {
                    _popUpVisible = true;
                    await App.Current.MainPage.DisplayAlert("UWAGA", "Nie zdołano nawiązać połączenia\nSpróbuj zresetować robota", "Zamknij");
                }
                    _popUpVisible = false;
            }
        }

        public async void Ping()
        {
            try
            {
                Console.WriteLine("Ping started");
                while (true)
                {
                    var segment = new ArraySegment<byte>(new byte[1024]);
                    await Client.ReceiveAsync(segment,new CancellationTokenSource(20000).Token);
                }
            }
            catch (Exception ex)
            {
                pong_thread.Abort();
            }
        }
        public void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = e.NewValue;
            maxSpeed = value;
            speedLabel.Text = "Prędkość: " + maxSpeed;

        }

        public async void StartAvoiding()
        {
            SendMessage("message:start_avoiding");
        }

        async void SafetyStop(object sender, EventArgs e)
        {
            int PORT = 12345;
            UdpClient udpClient = new UdpClient();
            udpClient.EnableBroadcast = true;
            IPEndPoint broadcast_ip = new IPEndPoint(IPAddress.Parse("255.255.255.255"), PORT);
            var data = Encoding.ASCII.GetBytes("stop");
            udpClient.Send(data, data.Length, broadcast_ip);
        }
        async void SendMessage(String message)
        {
            try
            {
                var byteMessage = Encoding.UTF8.GetBytes(message);
                var segment = new ArraySegment<byte>(byteMessage);
                await Client.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
            }catch(Exception ex)
            {
                if (!_popUpVisible)
                {
                    _popUpVisible = true;
                    await App.Current.MainPage.DisplayAlert("UWAGA", "Utracono połączenie z robotem\nSpróbuj ponownie się połączyć", "Zamknij");
                }
                _popUpVisible = false;
            }

        }

        public void ChangeControls(object sender, EventArgs args)
        {
            ChangeToArrows.IsVisible = !ChangeToArrows.IsVisible;
            ChangeToJoystick.IsVisible = !ChangeToJoystick.IsVisible;
            Arrows.IsVisible = !Arrows.IsVisible;
            Joystick.IsVisible = !Joystick.IsVisible;
            moveInfoLabel.IsVisible = !moveInfoLabel.IsVisible;
            moveSpeedLabel.IsVisible = !moveSpeedLabel.IsVisible;
            rotSpeedLabel.IsVisible = !rotSpeedLabel.IsVisible;
            joystickWidth = Joystick.WidthRequest;
            joystickHeight = Joystick.HeightRequest;
        }

        public void CustomClicked(object sender, EventArgs args)
        {
            
            if(sender is Button button)
            {
                Console.WriteLine("Moved " + button.Text);
            }
        }

        public void CustomPressed(object sender, EventArgs args)
        {
            if (sender is Button button)
            {
                Twist twist = new Twist();
                switch (button.Text)
                {
                    case "forward":
                        twist.Linear["x"] = maxSpeed;
                        break;
                    case "back":
                        twist.Linear["x"] = -maxSpeed;
                        break;
                    case "left":
                        twist.Angular["z"] = maxSpeed;
                        break;
                    case "right":
                        twist.Angular["z"] = -maxSpeed;
                        break;
                }
                var jsonString = JsonConvert.SerializeObject(twist);
                Console.WriteLine(jsonString);
                SendMessage(jsonString);
            }
        }

        public void CustomReleased(object sender, EventArgs args)
        {
            if (sender is Button button)
            {
                Twist twist = new Twist();
                var jsonString = JsonConvert.SerializeObject(twist);
                SendMessage(jsonString);
            }
        }

        public void OnTouch(object sender, TouchActionEventArgs args)
        {
            Twist twist = new Twist();
            if (args.Type != TouchActionType.Released)
            {
                var point = args.Location;
                if (point.X < 0) point.X = 0;
                if (point.Y < 0) point.Y = 0;
                if (point.X > joystickWidth) point.X = (float)joystickWidth;
                if (point.Y > joystickHeight) point.Y = (float)joystickHeight;
                var center = new Xamarin.Forms.Point(joystickWidth / 2, joystickHeight / 2);
                var pointFromCenter = new Xamarin.Forms.Point(point.X - center.X, point.Y - center.Y);
                var moveUnit = maxSpeed / (joystickHeight / 2);
                var rotUnit = maxSpeed / (joystickWidth / 2);
                var moveSpeed = Math.Round(-(moveUnit * pointFromCenter.Y), 3);
                var rotSpeed = Math.Round(-(rotUnit * pointFromCenter.X), 3);
                twist = new Twist(moveSpeed, 0.0, 0.0, 0.0, 0.0, rotSpeed);
            }
            moveSpeedLabel.Text = "Ruch: " + twist.Linear["x"].ToString() + (twist.Linear["x"] > 0 ? " (przód)" : " (tył)");
            rotSpeedLabel.Text = "Obrót: " + twist.Angular["z"].ToString() + (twist.Angular["z"] > 0 ? " (lewo)" : " (prawo)");
            var jsonString = JsonConvert.SerializeObject(twist);
            SendMessage(jsonString);
        }

    }

    
}