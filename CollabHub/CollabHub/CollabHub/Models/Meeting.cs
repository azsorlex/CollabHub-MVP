using System;
using System.Diagnostics;

namespace CollabHub.Models
{
    public class Meeting
    {
        private DateTime _date;

        public string UnitCode { get; set; }
        public string BGColour { get; set; }
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                Countdown = value - DateTime.Now;
            }
        }
        public TimeSpan Countdown { get; set; }
        public string Days => Countdown.Days.ToString("00");
        public string Hours => Countdown.Hours.ToString("00");
        public string Minutes => Countdown.Minutes.ToString("00");
        public bool IsLive => Countdown.Days <= 0 && Countdown.Hours <= 0 && Countdown.Minutes <= 0 && Countdown.Seconds <= 0; // Used to show the "Live!" label when the meeting is live 
        public bool IsNotLive => !IsLive; // Used to show the countdown when the meeting isn't live
    }
}