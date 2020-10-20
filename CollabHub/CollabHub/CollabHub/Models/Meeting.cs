using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CollabHub.Models
{
    public class Meeting : INotifyPropertyChanged
    {
        private DateTime _date;
        private TimeSpan _countdown;

        [PrimaryKey]
        public string ID { get; set; }
        public string UnitCode { get; set; }
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                Countdown = value - DateTime.Now;
            }
        }
        public DateTime EndDate { get; set; }
        public byte DurationHours { get; set; }
        public byte DurationMinutes { get; set; }
        public TimeSpan Countdown
        {
            get => _countdown;
            set
            {
                _countdown = value;
                OnPropertyChanged(nameof(Days));
                OnPropertyChanged(nameof(Hours));
                OnPropertyChanged(nameof(Minutes));
                OnPropertyChanged(nameof(IsLive));
                OnPropertyChanged(nameof(IsNotLive));
            }
        }
        public string BGColour { get; set; }
        public string Days => Countdown.Days.ToString("00");
        public string Hours => Countdown.Hours.ToString("00");
        public string Minutes => Countdown.Minutes.ToString("00");
        public bool IsLive => Countdown.Days <= 0 && Countdown.Hours <= 0 && Countdown.Minutes <= 0 && Countdown.Seconds <= 0; // Used to show the "Live!" label when the meeting is live
        public bool IsNotLive => !IsLive; // Used to show the countdown when the meeting isn't live

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}