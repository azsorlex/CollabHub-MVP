using System;
using System.Collections.Generic;
using System.Text;

namespace CollabHub.Models
{
    class Calendar_Alert
    {

        public string Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Icon { get; set; }
        public string Frequency { get; set; }
        public string Subject { get; set; }

        public Calendar_Alert(string Name, string Date, string Time, string Frequency, string Subject)
        {
            this.Name = Name;
            this.Date = Date;
            this.Time = Time;
            this.Time = Frequency;
            this.Time = Subject;
            this.Icon = "calendar.png";

        }

    }
}
