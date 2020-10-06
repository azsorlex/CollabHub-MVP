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

        public Calendar_Alert(string Name, string Date, string Time)
        {
            this.Name = Name;
            this.Date = Date;
            this.Time = Time;

        }

    }
}
