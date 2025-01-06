using PracaInzynierska.ViewModels;
using PracaInzynierska.Views;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using Xamarin.Forms;

namespace PracaInzynierska
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public ClientWebSocket Client  { get; set; } = null;
        public AppShell()
        {
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async void OnReconnectClicked(object sender, EventArgs e)
        {
            AboutPage page = AboutPage.GetInstance();
            page.GetConnection();
        }

        //private async void AvoidObstacles(object sender, EventArgs e)
        //{
        //    AboutPage page = AboutPage.GetInstance();
        //    page.StartAvoiding();
        //}
    }
}
