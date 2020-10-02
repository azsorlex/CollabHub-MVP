using System;
using Xamarin.Forms;
using CollabHub.ViewModels;

namespace CollabHub.Models
{
    public class Meeting
    {
        public string UnitCode { get; set; }
        public string BGColour { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeSpan => Date - DateTime.Now;
        public string Days => TimeSpan.Days.ToString("00");
        public string Hours => TimeSpan.Hours.ToString("00");
        public string Minutes => TimeSpan.Minutes.ToString("00");
        public Command TapCommand { get; set; }
    }
}