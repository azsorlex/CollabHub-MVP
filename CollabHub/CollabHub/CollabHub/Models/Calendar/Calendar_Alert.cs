using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollabHub.Models
{
    public class Calendar_Alert
    {
        
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Datestring { get; set; }

        public string Time { get; set; }
        public string Icon { get; set; }
        public string Frequency { get; set; }
        public string Subject { get; set; }

        public Calendar_Alert(string Name, DateTime Date, string Time, string Frequency, string Subject)
        {
            this.Name = Name;
            this.Date = Date;
            this.Time = Time;
            this.Frequency = Frequency;
            this.Subject = Subject;
            this.Icon = "calendar.png";
            this.Datestring = Date.ToString("d");

        }

    }
}
