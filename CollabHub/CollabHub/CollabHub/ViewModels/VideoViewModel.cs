using Xamarin.Forms;
using MvvmHelpers.Commands;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using CollabHub.Models;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CollabHub.ViewModels
{
    class VideoViewModel : BaseViewModel
    {
        private readonly ToastNotification NotLiveMessage;
        private IList<Meeting> _meetings;
        public IList<Meeting> Meetings
        {
            get => _meetings;
            set => SetProperty(ref _meetings, value);
        }
        public MvvmHelpers.Commands.Command TapCommand { get; }
        
        public VideoViewModel()
        {
            NotLiveMessage = new ToastNotification("This video meeting hasn't gone live yet.", 3000);
            Meetings = new List<Meeting>();
            TapCommand = new MvvmHelpers.Commands.Command(async (m) => await TapAction((Meeting)m));

            List<string> UnitCodes = new List<string>()
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

            long start = DateTime.Now.Ticks;
            for (int i = 0; i < UnitCodes.Count; i++)
            {
                Meetings.Add(new Meeting
                {
                    UnitCode = UnitCodes[i],
                    BGColour = BGColours[i % BGColours.Count],
                    Date = new DateTime(start + new TimeSpan(0, 0, i, 0).Ticks),
                });
            }

            // Start a timer that activates every second and updates the items in Meetings
            StoppableTimer.Start(new TimeSpan(0, 0, 1), UpdateCountdowns);
        }

        private async Task TapAction(Meeting m)
        {
            if (m.Countdown.Days == 0 && m.Countdown.Hours == 0 && m.Countdown.Minutes < 5)
            {
                StoppableTimer.Stop();
                await Shell.Current.GoToAsync("home"); // Go to the video page if there are 5 or less minutes until the meeting starts
            }
            else  // Otherwise display a toast message
            {
                NotLiveMessage.Show();
            }
        }

        private void UpdateCountdowns() // Update the countdown for each meeting, which will in turn update all of the other parameters
        {
            DateTime currentTime = DateTime.Now;
            foreach (Meeting m in Meetings)
            {
                m.Countdown = m.Date - currentTime; // This alone is enough to update the View
                if (m.IsLive && m.Countdown.Minutes == -1) // Add 7 days to the date if the meeting is over and reorder the list
                {
                    m.Date = new DateTime(m.Date.Ticks + new TimeSpan(7, 0, 0, 0).Ticks);
                    Meetings = Meetings.OrderBy(m2 => m2.Date).ToList();
                }
            }
        }
    }
}
