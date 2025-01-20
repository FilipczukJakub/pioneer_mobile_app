using System;
using System.IO;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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
using System.Linq;
using PracaInzynierska.ViewModels;
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
        private string robotIp;
        private CancellationTokenSource _backgroundTaskCancellationTokenSource;
        private bool connecting = false;
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
            _backgroundTaskCancellationTokenSource = new CancellationTokenSource();
            CreateConnection();

        }

        private void StopTasks()
        {
            _backgroundTaskCancellationTokenSource?.Cancel();
            _backgroundTaskCancellationTokenSource.Dispose();
            _backgroundTaskCancellationTokenSource = new CancellationTokenSource();
        }

        private async Task Disconnect()
        {
            StopTasks();
            try
            {
                if (!Object.Equals(Client, null) && Client.State == WebSocketState.Open)
                {
                    await Client.CloseAsync(WebSocketCloseStatus.NormalClosure, "Reconnection", CancellationToken.None);
                    Client.Dispose();
                    Client = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void CreateConnection(ConnectionMode mode = ConnectionMode.Full)
        {
            if (!connecting)
            {
                connecting = true;
                await Disconnect();
                try
                {

                    robotIp = await BroadcastMessage();
                    if (mode == ConnectionMode.Full || mode == ConnectionMode.Movement)
                        await MovementConnection();
                    cameraFeed.Source = $"http://{robotIp}:8767/index.html";
                    AlertWindow("Sukces", "Nawiązano połączenie z robotem");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    AlertWindow("UWAGA", "Nie zdołano pozyskać adresu robota\nSpróbuj zresetować robota");
                }
                connecting = false;
            }
            
        }

        private async void AlertWindow(string header, string message)
        {
            if (!_popUpVisible)
            {
                _popUpVisible = true;
                await App.Current.MainPage.DisplayAlert(header, message, "Zamknij");
            }
            _popUpVisible = false;
        }

        private async Task<string> BroadcastMessage()
        {
            try
            {
                int PORT = 12345;
                UdpClient udpClient = new UdpClient();
                udpClient.EnableBroadcast = true;
                IPEndPoint broadcastIp = new IPEndPoint(IPAddress.Parse("255.255.255.255"), PORT);
                IPEndPoint any_ip = new IPEndPoint(IPAddress.Any, 0);
                var data = Encoding.ASCII.GetBytes("ip_request");
                await udpClient.SendAsync(data, data.Length, broadcastIp);
                udpClient.Client.ReceiveTimeout = 2000;
                var result = udpClient.ReceiveAsync();
                return Encoding.ASCII.GetString(result.Result.Buffer);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                AlertWindow("UWAGA", "Nie zdołano pozyskać adresu robota\nSpróbuj zresetować robota");
                return null;
            }
        }

        public async Task MovementConnection()
        {
            try
            {
                Uri serverUri = new Uri($"ws://{robotIp}:8765");
                var client = new ClientWebSocket();
                await client.ConnectAsync(serverUri, _backgroundTaskCancellationTokenSource.Token);

                Client = client;

                _ = Task.Run(Ping, _backgroundTaskCancellationTokenSource.Token);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                AlertWindow("UWAGA", "Nie zdołano nawiązać połączenia\nSpróbuj zresetować robota");
            }  
        }


        public ImageSource ByteArrayToImageSource(byte[] imageData)
        {
            return ImageSource.FromStream(() => new MemoryStream(imageData));
        }


        public async Task Ping()
        {
            try
            {
                var cancellationToken = this._backgroundTaskCancellationTokenSource.Token;
                var segment = new ArraySegment<byte>(new byte[1024]);
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        await Client.ReceiveAsync(segment, cancellationToken);
                    }
                    catch (Exception ex) {
                        break;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                AlertWindow("UWAGA", "System PING nie odpowiada");
            }
        }

        async void SafetyStop(object sender, EventArgs e)
        {
            int PORT = 12345;
            UdpClient udpClient = new UdpClient();
            udpClient.EnableBroadcast = true;
            IPEndPoint broadcast_ip = new IPEndPoint(IPAddress.Parse("255.255.255.255"), PORT);
            var data = Encoding.ASCII.GetBytes("stop");
            await udpClient.SendAsync(data, data.Length, broadcast_ip);
        }
        void SendMessage(String message)
        {
            try
            {
                var byteMessage = Encoding.UTF8.GetBytes(message);
                var segment = new ArraySegment<byte>(byteMessage);
                Client.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                AlertWindow("UWAGA", "Utracono połączenie z robotem\nSpróbuj połączyć się ponownie");
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

        public void CustomMovePressed(object sender, EventArgs args)
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
                SendMessage("move###" + jsonString);
            }
        }

        public void CustomMoveReleased(object sender, EventArgs args)
        {
            if (sender is Button button)
            {
                Twist twist = new Twist();
                var jsonString = JsonConvert.SerializeObject(twist);
                SendMessage("move###" + jsonString);
            }
        }

        public void CustomGripperPressed(object sender, EventArgs args)
        {
            if (sender is Button button)
            {
                int command = 2;
                switch (button.Text)
                {
                    case "up":
                        command = 3;
                        break;
                    case "down":
                        command = 4;
                        break;
                    case "open":
                        command = 0;
                        break;
                    case "close":
                        command = 1;
                        break;
                }
                var jsonString = JsonConvert.SerializeObject(command);
                SendMessage("gripper###" + jsonString);
            }
        }

        public void CustomGripperReleased(object sender, EventArgs args)
        {
            if (sender is Button button)
            {
                int command = 2;
                switch (button.Text)
                {
                    case "up":
                        command = 5;
                        break;
                    case "down":
                        command = 5;
                        break;
                    case "open":
                        command = 2;
                        break;
                    case "close":
                        command = 2;
                        break;
                }
                var jsonString = JsonConvert.SerializeObject(command);
                SendMessage("gripper###" + jsonString);
            }
        }

        public void OnMoveTouch(object sender, TouchActionEventArgs args)
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
            SendMessage("move###" + jsonString);
        }

    }

    
}