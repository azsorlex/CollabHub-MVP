using Xamarin.Forms;
using MvvmHelpers.Commands;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using CollabHub.Views;
using CollabHub.Models.Chat;
using CollabHub.Models;
using CollabHub.Services;

namespace CollabHub.ViewModels
{
    class HomeViewModel : BaseViewModel
    {
        public Xamarin.Forms.Command CalendarPage { get; set; }
        public Xamarin.Forms.Command ChatPage { get; set; }
        public Xamarin.Forms.Command UnitsPage { get; set; }
        public Xamarin.Forms.Command MeetingPage { get; set; }

        public string Date { get; set; }

        public User CurrentUser { get; set; }

        public HomeViewModel()
        {
            Date = $"Today is {DateTime.Today:D}";
            CalendarPage = new Xamarin.Forms.Command(GoToCalendarPage);
            ChatPage = new Xamarin.Forms.Command(GoToChatPage);
            UnitsPage = new Xamarin.Forms.Command(GoToUnitsPage);
            MeetingPage = new Xamarin.Forms.Command(GoToMeetingPage);

            CurrentUser = UserDataStore.CurrentUser;

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
        async void GoToMeetingPage()
        {
            await Shell.Current.GoToAsync("meeting");
        }

    }
}
