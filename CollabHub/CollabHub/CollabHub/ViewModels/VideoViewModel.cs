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
        private List<string> UnitCodes;

        private bool someCondition = true;


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
            List<string> BGColours = new List<string>()
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
                    BGColour = BGColours[i % BGColours.Count],
                    TapCommand = OnTapped()
                });
            }
        }

        public Xamarin.Forms.Command OnTapped()
        {
            someCondition = !someCondition;
            if (someCondition) // Will be replaced with the particular meeting's countdown
            {
                return new Xamarin.Forms.Command(GoToVideoPage);
            }
            return new ToastNotification("This video meeting hasn't gone live yet.", 3000).TapCommand;
        }

        async void GoToVideoPage()
        {
            await Shell.Current.GoToAsync("home"); // Will be substituted for a new page
        }
    }
}
