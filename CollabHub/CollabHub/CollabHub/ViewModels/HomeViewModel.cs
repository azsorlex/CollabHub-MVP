using Xamarin.Forms;
using MvvmHelpers.Commands;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using CollabHub.Views;

namespace CollabHub.ViewModels
{
    class HomeViewModel : BaseViewModel
    {
        public Xamarin.Forms.Command AboutPage { get; set; }
        public HomeViewModel()
        {
            Title = "Test Binding";
            AboutPage = new Xamarin.Forms.Command(GoToAboutPage);
        }

        async void GoToAboutPage()
        {
            await Shell.Current.GoToAsync("units"); 
        }
    }
}
