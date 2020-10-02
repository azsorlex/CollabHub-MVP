using Xamarin.Forms;
using MvvmHelpers.Commands;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using CollabHub.Views;
using CollabHub.Models;
using System.Diagnostics;

namespace CollabHub.ViewModels
{
    class VideoViewModel : BaseViewModel
    {
        public IList<Meeting> Meetings { get; private set; }
        private List<string> UnitCodes;


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
                    Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(0, 0, i * 2, 0).Ticks)
                });
            }

            // This has to be in its own loop because for whatever reason in the previous one,
            // the Meetings array wouldn't have the added item added to it until the next iteration
            // of the loop. This way, the Meetings array is fully populated, and the OnTapped command
            // will successfuly work with the Meetings function.
            for (int i = 0; i < UnitCodes.Count; i++)
            {
                Meetings[i].TapCommand = OnTapped(i);
            }
        }

        public Xamarin.Forms.Command OnTapped(int i)
        {
            // I also discovered that variables can't be changed here. If a boolean is true, and then it gets
            // set as false; the bottom if statement would always evaluate false. A static condition such as
            // this one must be used.
            if (int.Parse(Meetings[i].Minutes) < 5) // Will be replaced with the particular meeting's countdown
            {
                return new Xamarin.Forms.Command(GoToVideoPage);
            }

            return new ToastNotification("This video meeting hasn't gone live yet.", 3000).TapCommand;
        }

        private async void GoToVideoPage()
        {
            await Shell.Current.GoToAsync("home"); // Will be substituted for a new page
        }
    }
}
