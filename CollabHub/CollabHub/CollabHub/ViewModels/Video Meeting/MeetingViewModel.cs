using Xamarin.Forms;
using MvvmHelpers.Commands;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using CollabHub.Models;
using CollabHub.Models.GlobalUtilities;
using System.Diagnostics;
using System.Threading.Tasks;
using CollabHub.Services;
using System.Collections.ObjectModel;

namespace CollabHub.ViewModels
{
    class MeetingViewModel : BaseViewModel
    {
        private readonly ToastNotification NotLiveMessage;
        private readonly MeetingDataStore DataStore;
        public ObservableCollection<Meeting> Meetings { get; set; }
        public MvvmHelpers.Commands.Command TapCommand { get; }

        public MeetingViewModel()
        {
            NotLiveMessage = new ToastNotification("This video meeting hasn't gone live yet.", 3000);
            DataStore = new MeetingDataStore();
            Meetings = new ObservableCollection<Meeting>();
            TapCommand = new MvvmHelpers.Commands.Command(async (m) => await TapAction((Meeting)m));

            MvvmHelpers.Commands.Command LoadItemsCommand = new MvvmHelpers.Commands.Command(async () => await ExecuteLoadItemsCommand(true));
            LoadItemsCommand.Execute(null); // Load the remote source

            // Start a timer that activates every second and updates the items in Meetings
            StoppableTimer.Start(new TimeSpan(0, 0, 1), UpdateCountdowns);
        }

        async Task ExecuteLoadItemsCommand(bool initialise)
        {
            IsBusy = true;

            List<string> BGColours = new List<string>()
            {
                "#C1EDCC",
                "#B0C0BC",
                "#A7A7A9"
            };

            try
            {
                byte i = 0;
                Meetings.Clear();
                var meetings = await DataStore.GetItemsAsync(true);
                foreach (Meeting m in meetings)
                {
                    m.BGColour = BGColours[i++ % BGColours.Count];
                    Meetings.Add(m);
                }
                if (initialise)
                {
                    UpdateCountdowns();
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

        private async void UpdateCountdowns() // Update the countdown for each meeting, which will in turn update all of the other meetings' parameters
        {
            bool reorder = false;
            DateTime currentTime = DateTime.Now;
            List<Meeting> ItemsToUpdate = new List<Meeting>();
            List<Meeting> ItemsToDelete = new List<Meeting>();
            foreach (Meeting m in Meetings)
            {
                m.Countdown = m.Date - currentTime;
                // Add 7 days to the date if the meeting is over and reorder the list. Using while to allow the initial date to catch up to the present
                while (m.Countdown.Days < 0 || (m.IsLive && m.Countdown.Hours <= -m.DurationHours && m.Countdown.Minutes <= m.DurationMinutes))
                {
                    if (m.Date < m.EndDate)
                    {
                        if (!ItemsToUpdate.Contains(m))
                            ItemsToUpdate.Add(m);
                        m.Date += new TimeSpan(7, 0, 0, 0);
                        reorder = true;
                    }
                    else
                    {
                        ItemsToDelete.Add(m);
                        break;
                    }
                }
            }
            
            foreach (Meeting m in ItemsToUpdate)
            {
                await DataStore.UpdateItemAsync(m);
            }
            foreach (Meeting m in ItemsToDelete)
            {
                await DataStore.DeleteItemAsync(m.ID);
            }
            if (reorder)
            {
                await ExecuteLoadItemsCommand(false);
            }
        }
    }
}