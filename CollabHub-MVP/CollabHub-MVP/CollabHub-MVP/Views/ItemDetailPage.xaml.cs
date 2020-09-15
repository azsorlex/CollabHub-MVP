using System.ComponentModel;
using Xamarin.Forms;
using CollabHub_MVP.ViewModels;

namespace CollabHub_MVP.Views
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