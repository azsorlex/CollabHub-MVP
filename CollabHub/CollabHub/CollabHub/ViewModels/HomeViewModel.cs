using Xamarin.Forms;
using MvvmHelpers.Commands;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollabHub.ViewModels
{
    class HomeViewModel : BaseViewModel
    {
        public Xamarin.Forms.Command AboutPage { get; set; }
        public HomeViewModel()
        {
            AboutPage = new Xamarin.Forms.Command(GoToAboutPage);
        }

        async void GoToAboutPage()
        {
            await Shell.Current.GoToAsync("//about"); 
        }
    }
}
