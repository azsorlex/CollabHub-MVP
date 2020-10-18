using Xamarin.Forms;
using MvvmHelpers.Commands;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using CollabHub.Models;
using CollabHub.Models.GlobalUtilities;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using CollabHub.Services;
using System.Collections.ObjectModel;

namespace CollabHub.ViewModels
{
    class MeetingViewModel : BaseViewModel
    {
        private readonly ToastNotification NotLiveMessage;
        private readonly MockMeetingDataStore DataStore;
        public ObservableCollection<Meeting> Meetings { get; set; }
        public MvvmHelpers.Commands.Command TapCommand { get; }

        public MeetingViewModel()
        {
            NotLiveMessage = new ToastNotification("This video meeting hasn't gone live yet.", 3000);
            DataStore = new MockMeetingDataStore();
            Meetings = new ObservableCollection<Meeting>();
            TapCommand = new MvvmHelpers.Commands.Command(async (m) => await TapAction((Meeting)m));

            MvvmHelpers.Commands.Command LoadItemsCommand = new MvvmHelpers.Commands.Command(async () => await ExecuteLoadItemsCommand());
            LoadItemsCommand.Execute(null); // Load the remote source

            ReorderCollection(true);

            // Start a timer that activates every second and updates the items in Meetings
            StoppableTimer.Start(new TimeSpan(0, 0, 1), UpdateCountdowns);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Meetings.Clear();
                var meetings = await DataStore.GetItemsAsync(true);
                foreach (var m in meetings)
                {
                    Meetings.Add(m);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task TapAction(Meeting m)
        {
            if (m.Countdown.Days == 0 && m.Countdown.Hours <= 0 && m.Countdown.Minutes < 5)
            {
                await Shell.Current.GoToAsync($"video?unitcode={m.UnitCode}"); // Go to the video page if there are 5 or less minutes until the meeting starts
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
                        reorder = true;
                    }
                    else
                    {
                        ItemsToDelete.Add(m); // Mark the meeting for deletion if there are no more occurences
                        break;
                    }
                }
            }

            if (ItemsToDelete.Count > 0)
            {
                foreach (Meeting m in ItemsToDelete)
                {
                    Meetings.Remove(m);
                }
                MeetingDataStore.Meetings = Meetings; // Update the remote source
            }
            if (reorder)
            {
                ReorderCollection(false);
            }
        }

        private void ReorderCollection(bool colourise)
        {
            List<string> BGColours = new List<string>()
            {
                "#C1EDCC",
                "#B0C0BC",
                "#A7A7A9"
            };

            List<Meeting> temp = Meetings.OrderBy(m => m.Date).ToList();
            Meetings.Clear();
            for (int i = 0; i < temp.Count; i++)
            {
                if (colourise)
                    temp[i].BGColour = BGColours[i % BGColours.Count];
                Meetings.Add(temp[i]);
            }
            MeetingDataStore.Meetings = Meetings; // Update the remote source
        }
    }
}