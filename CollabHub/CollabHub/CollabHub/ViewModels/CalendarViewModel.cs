using Xamarin.Forms;
using MvvmHelpers.Commands;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using CollabHub.Views;

namespace CollabHub.ViewModels
{
    class CalendarViewModel : BaseViewModel
    {
        public Xamarin.Forms.Command AddAlert { get; set; }

        public CalendarViewModel()
        {
            AddAlert = new Xamarin.Forms.Command(GoToAddAlert);
        }
        async void GoToAddAlert()
        {
            await Shell.Current.GoToAsync("addalert");
        }
    }
}
