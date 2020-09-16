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
        public Xamarin.Forms.Command UnitsPage { get; set; }
        public HomeViewModel()
        {
            Title = "Test Binding";
            UnitsPage = new Xamarin.Forms.Command(GoToUnitsPage);
        }

        async void GoToUnitsPage()
        {
            await Shell.Current.GoToAsync("units"); 
        }
    }
}
