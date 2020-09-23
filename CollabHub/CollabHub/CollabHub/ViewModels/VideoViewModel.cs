using Xamarin.Forms;
using MvvmHelpers.Commands;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using CollabHub.Views;
using CollabHub.Models;

namespace CollabHub.ViewModels
{
    class VideoViewModel : BaseViewModel
    {
        public IList<Meeting> Meetings { get; private set; }
        public Xamarin.Forms.Command HomePage { get; set; }

        public VideoViewModel()
        {
            Meetings = new List<Meeting>();
            Meetings.Add(new Meeting
            {
                UnitCode = "IAB330"
            });
            Meetings.Add(new Meeting
            {
                UnitCode = "CAB432"
            });
            Meetings.Add(new Meeting
            {
                UnitCode = "CAB401"
            });
            Meetings.Add(new Meeting
            {
                UnitCode = "IFB103"
            });
            Meetings.Add(new Meeting
            {
                UnitCode = "IFB104"
            });

            HomePage = new Xamarin.Forms.Command(GoToHomePage);
        }

        async void GoToHomePage()
        {
            await Shell.Current.GoToAsync("home");
        }
    }
}
