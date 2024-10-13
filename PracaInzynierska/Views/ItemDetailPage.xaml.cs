using PracaInzynierska.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PracaInzynierska.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}