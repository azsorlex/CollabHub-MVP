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
using CollabHub.Services;
using System.Collections.ObjectModel;

namespace CollabHub.ViewModels
{
    class VideoViewModel : BaseViewModel
    {
        private readonly ToastNotification NotLiveMessage;
        public ObservableCollection<Meeting> Meetings { get; set; }
        public MvvmHelpers.Commands.Command TapCommand { get; }

        public VideoViewModel()
        {
            NotLiveMessage = new ToastNotification("This video meeting hasn't gone live yet.", 3000);
            Meetings = MeetingDataStore.Meetings; // Load the remote source
            TapCommand = new MvvmHelpers.Commands.Command(async (m) => await TapAction((Meeting)m));

            UpdateCountdowns();

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

        private void UpdateCountdowns() // Update the countdown for each meeting, which will in turn update all of the other meetings' parameters
        {
            bool reorder = false;
            List<Meeting> ItemsToDelete = new List<Meeting>();
            DateTime currentTime = DateTime.Now;
            foreach (Meeting m in Meetings)
            {
                m.Countdown = m.Date - currentTime;
                // Add 7 days to the date if the meeting is over and reorder the list. Using while to allow the initial date to catch up to the present
                while (m.Countdown.Days < 0 || (m.IsLive && m.Countdown.Hours <= -m.Duration.Key && m.Countdown.Minutes <= m.Duration.Value))
                {
                    if (m.Date < m.EndDate)
                    {
                        m.Date += new TimeSpan(7, 0, 0, 0);
                        reorder = m.Countdown.Days >= 0;
                    }
                    else
                    {
                        ItemsToDelete.Add(m); // Mark the meeting for deletion if there are no more occurences
                        MeetingDataStore.Meetings = Meetings; // Update the remote source
                        break;
                    }
                }
            }

            foreach (Meeting m in ItemsToDelete)
            {
                Meetings.Remove(m);
            }
            if (reorder)
            {
                List<Meeting> temp = Meetings.OrderBy(m => m.Date).ToList();
                Meetings.Clear();
                foreach (Meeting m in temp)
                {
                    Meetings.Add(m);
                }
                MeetingDataStore.Meetings = Meetings; // Update the remote source
            }
        }
    }
}