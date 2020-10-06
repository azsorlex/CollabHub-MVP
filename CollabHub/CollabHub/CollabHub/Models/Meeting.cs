using System;
using Xamarin.Forms;
using CollabHub.ViewModels;
using System.Diagnostics;

namespace CollabHub.Models
{
    public class Meeting
    {
        public string UnitCode { get; set; }
        public string BGColour { get; set; }
        public DateTime Date { get; set; }
        private TimeSpan TimeSpan => Date - DateTime.Now;
        public string Days => TimeSpan.Days.ToString("00");
        public string Hours => TimeSpan.Hours.ToString("00");
        public string Minutes => TimeSpan.Minutes.ToString("00");
        public Command TapCommand
        {
            get
            {
                if (TimeSpan.Minutes < 5) // Go to the video page if there are 5 or less minutes until the meeting starts
                {
                    return new Command(async () => { await Shell.Current.GoToAsync("home"); });
                }
                return new ToastNotification("This video meeting hasn't gone live yet.", 3000).TapCommand; // Otherwise display a message
            }
        }
        public bool IsLive // Used to show the "Live!" label when the meeting is live
        {
            get
            {
                // This condition will probably chance once I implement the video page
                if (TimeSpan.Minutes == -1) {
                    Date = new DateTime(Date.Ticks + new TimeSpan(7, 0, 0, 0).Ticks); // Set the meeting to appear in one week time
                    return false;
                }
                return TimeSpan.Seconds <= 0;
            }
        }
        public bool IsNotLive => !IsLive; // Used to show the countdown when the meeting isn't live
    }
}