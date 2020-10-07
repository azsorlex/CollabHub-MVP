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
        public Xamarin.Forms.Command CalendarPage { get; set; }
        public Xamarin.Forms.Command ChatPage { get; set; }
        public Xamarin.Forms.Command UnitsPage { get; set; }
        public Xamarin.Forms.Command VideoPage { get; set; }

        public string Date { get; set; }

        public HomeViewModel()
        {
            DateTime today = DateTime.Today;
            Date = $"Today is {today.ToString("D")}";
            CalendarPage = new Xamarin.Forms.Command(GoToCalendarPage);
            ChatPage = new Xamarin.Forms.Command(GoToChatPage);
            UnitsPage = new Xamarin.Forms.Command(GoToUnitsPage);
            VideoPage = new Xamarin.Forms.Command(GoToVideoPage);
        }

        async void GoToUnitsPage()
        {
            await Shell.Current.GoToAsync("units"); 
        }

        async void GoToCalendarPage()
        {
            await Shell.Current.GoToAsync("calendar");
        }

        async void GoToChatPage()
        {
            await Shell.Current.GoToAsync("chat");
        }
        async void GoToVideoPage()
        {
            await Shell.Current.GoToAsync("video");
        }
    }
}
