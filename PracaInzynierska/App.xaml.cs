using PracaInzynierska.Services;
using Xamarin.Forms;
using System.Net.WebSockets;
using System.Threading;
using System.Text;
using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;
namespace PracaInzynierska
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            //Uri serverUri = new Uri("ws://192.168.1.100:8765");
            //var client = new ClientWebSocket();

            //try
            //{
            //    await client.ConnectAsync(serverUri, CancellationToken.None);
            //    ((AppShell)MainPage).Client = client;
            //    if (client.State == WebSocketState.Open)
            //    {
            //        var byteMessage = Encoding.UTF8.GetBytes("-hello");
            //        var segment = new ArraySegment<byte>(byteMessage);
            //        await client.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
            //    }
            //}catch (Exception ex)
            //{
            //    Console.WriteLine("Nie udało połączyć się z robotem");
            //    Console.WriteLine(client.State);
            //}
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private static StreamReader ExecuteCommandLine(String file, String arguments = "")
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = file;
            startInfo.Arguments = arguments;

            Process process = Process.Start(startInfo);

            return process.StandardOutput;
        }
    }
}
