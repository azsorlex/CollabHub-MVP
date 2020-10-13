using System;
using System.Text;
using CollabHub.Models.GlobalUtilities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollabHub.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPage : ContentPage
    {
        public VideoPage()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            StoppableTimer.Stop(true); // Stop the running timer when the page dissapears. Including when the device's back button is pressed
            base.OnDisappearing();
        }
    }
}