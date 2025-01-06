using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PracaInzynierska.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ImageSource imageSource;
        public AboutViewModel()
        {
            Title = "Pioneer 3-DX";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }


    }
}