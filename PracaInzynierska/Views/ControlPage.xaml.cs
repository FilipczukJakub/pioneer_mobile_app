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
        public static ClientWebSocket Camera;
        private static AboutPage _instance;
        private bool _popUpVisible = false;
        private double joystickWidth;
        private double joystickHeight;
        private double maxSpeed = 1.0;
        private Thread pong_thread;
        private Thread camera_thread;
        private ImageSource imageSource;
        private string robotIp;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
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
            CreateConnection();
        }

        private void StopThreads()
        {
            this._cancellationTokenSource.Cancel();
        }

        public async void CreateConnection(ConnectionMode mode = ConnectionMode.Full)
        {
            StopThreads();
            if (!Object.Equals(Client,null) && Client.State != WebSocketState.Aborted)
            {
                await Client.CloseAsync(WebSocketCloseStatus.NormalClosure, "Reconnection", CancellationToken.None);
            }
            if (!Object.Equals(Camera, null) && Camera.State != WebSocketState.Aborted)
            {
                await Camera.CloseAsync(WebSocketCloseStatus.NormalClosure, "Reconnection", CancellationToken.None);

            }
            //if (!Object.Equals(camera_thread, null) && camera_thread.ThreadState == ThreadState.Running)
            //{
            //    camera_thread.Abort();
            //}
            //if (!Object.Equals(pong_thread,null) && pong_thread.ThreadState == ThreadState.Running)
            //{
            //    pong_thread.Abort();
            //}
            try
            {
                
                robotIp = await BroadcastMessage();
                if(mode == ConnectionMode.Full || mode == ConnectionMode.Movement)
                    MovementConnection();
                if(mode == ConnectionMode.Full || mode == ConnectionMode.Camera)
                    CameraConnection();
                AlertWindow("Sukces", "Nawiązano połączenie z robotem");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                AlertWindow("UWAGA", "Nie zdołano pozyskać adresu robota\nSpróbuj zresetować robota");
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
                IPEndPoint broadcast_ip = new IPEndPoint(IPAddress.Parse("255.255.255.255"), PORT);
                IPEndPoint any_ip = new IPEndPoint(IPAddress.Any, 0);
                var data = Encoding.ASCII.GetBytes("ip_request");
                udpClient.Send(data, data.Length, broadcast_ip);
                udpClient.Client.ReceiveTimeout = 2000;
                byte[] bytes = udpClient.Receive(ref any_ip);
                //robotIp = Encoding.ASCII.GetString(bytes);
                return Encoding.ASCII.GetString(bytes);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                AlertWindow("UWAGA", "Nie zdołano pozyskać adresu robota\nSpróbuj zresetować robota");
                return null;
            }
        }

        public async void MovementConnection()
        {
            try
            {
                Uri serverUri = new Uri($"ws://{robotIp}:8765");
                var client = new ClientWebSocket();
                await client.ConnectAsync(serverUri, CancellationToken.None);

                Client = client;

                pong_thread = new Thread(new ThreadStart(Ping));
                pong_thread.Start();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                AlertWindow("UWAGA", "Nie zdołano nawiązać połączenia\nSpróbuj zresetować robota");
            }  
        }

        public async void CameraConnection()
        {
            try
            {
                Uri cameraUri = new Uri($"ws://{robotIp}:8767");
                var camera = new ClientWebSocket();
                await camera.ConnectAsync(cameraUri, CancellationToken.None);
                Camera = camera;
                camera_thread = new Thread(new ThreadStart(CameraFeed));
                camera_thread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                AlertWindow("UWAGA", "Nie zdołano nawiązać połączenia z kamerą\nSpróbuj zresetować robota");
            }
        }

        public async void CameraFeed()
        {
            var cancellationToken = this._cancellationTokenSource.Token;
            try
            {
                var buffer = new byte[1024];
                var recievedData = new MemoryStream();
                var result = new WebSocketReceiveResult(0,WebSocketMessageType.Binary,false);
                while (!cancellationToken.IsCancellationRequested)
                {
                    result = await Camera.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);
                    recievedData.Write(buffer,0,result.Count);
                    if (result.EndOfMessage)
                    {

                        imageSource = ByteArrayToImageSource(recievedData.ToArray());
                        recievedData.SetLength(0);
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            if (background_image1.Opacity == 1)
                            {
                                background_image2.Opacity = background_image2.Opacity == 1 ? 0 : 1;
                                background_image1.Source = imageSource;
                                background_image1.Opacity = background_image1.Opacity == 1 ? 0 : 1;
                            }
                            else
                            {
                                background_image1.Opacity = background_image1.Opacity == 1 ? 0 : 1;
                                background_image2.Source = imageSource;
                                background_image2.Opacity = background_image2.Opacity == 1 ? 0 : 1;
                            }
                        });
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                AlertWindow("UWAGA", "Utracono połączenie z kamerą");
            }
        }

        public ImageSource ByteArrayToImageSource(byte[] imageData)
        {
            return ImageSource.FromStream(() => new MemoryStream(imageData));
        }


        public void Ping()
        {
            var cancellationToken = this._cancellationTokenSource.Token;
            try
            {
                Console.WriteLine("Ping started");
                var segment = new ArraySegment<byte>(new byte[1024]);
                while (!cancellationToken.IsCancellationRequested)
                {
                    Client.ReceiveAsync(segment,cancellationToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                AlertWindow("UWAGA", "System PING nie odpowiada");

                pong_thread.Abort();
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