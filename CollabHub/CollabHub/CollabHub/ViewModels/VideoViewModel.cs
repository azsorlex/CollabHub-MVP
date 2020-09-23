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
        private List<string> UnitCodes;
        private List<string> BGColours;

        public VideoViewModel()
        {
            UnitCodes = new List<string>()
            {
                "IAB330",
                "CAB432",
                "CAB401",
                "IFB399",
                "IFB104"
            };

            BGColours = new List<string>()
            {
                "#C1EDCC",
                "#B0C0BC",
                "#A7A7A9"
            };
            Meetings = new List<Meeting>();

            for (int i = 0; i < UnitCodes.Count; i++)
            {
                Meetings.Add(new Meeting
                {
                    UnitCode = UnitCodes[i],
                    BGColour = BGColours[i % BGColours.Count]
                });
            }

            HomePage = new Xamarin.Forms.Command(GoToHomePage);
        }

        async void GoToHomePage()
        {
            await Shell.Current.GoToAsync("home");
        }
    }
}
