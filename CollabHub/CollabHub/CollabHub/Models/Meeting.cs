using System;
using System.Diagnostics;
using MvvmHelpers;

namespace CollabHub.Models
{
    public class Meeting : BaseViewModel
    {
        private DateTime _date;
        private TimeSpan _countdown;
        private string _days;
        private string _hours;
        private string _minutes;
        private bool _islive;
        private bool _isnotlive;

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
        public TimeSpan Countdown
        {
            get => _countdown;
            set
            {
                SetProperty(ref _countdown, value);
                Days = value.Days.ToString("00");
                Hours = value.Hours.ToString("00");
                Minutes = value.Minutes.ToString("00");
                IsLive = value.Days == 0 && value.Hours <= 0 && value.Minutes <= 0 && value.Seconds <= 0;
            }
        }
        public string Days
        {
            get => _days;
            set => SetProperty(ref _days, value);
        }
        public string Hours
        {
            get => _hours;
            set => SetProperty(ref _hours, value);
        }
        public string Minutes
        {
            get => _minutes;
            set => SetProperty(ref _minutes, value);
        }
        public bool IsLive // Used to show the "Live!" label when the meeting is live
        {
            get => _islive;
            set
            {
                SetProperty(ref _islive, value);
                IsNotLive = !value;
            }
        }
        public bool IsNotLive // Used to show the countdown when the meeting isn't live
        {
            get => _isnotlive;
            set => SetProperty(ref _isnotlive, value);
        }
    }
}