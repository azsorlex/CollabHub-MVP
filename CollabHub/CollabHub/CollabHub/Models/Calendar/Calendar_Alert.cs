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

        public string DisplayDate { get; set; }
        public string Time { get; set; }
        public string Icon { get; set; }
        public string Frequency { get; set; }
        public string Subject { get; set; }
        public bool Auto { get; set; }

        public Calendar_Alert(string Name, DateTime Date, string Time, string Frequency, string Subject, bool auto)
        {
            this.Name = Name;
            this.Date = Date;
            this.Time = Time;
            this.Frequency = Frequency;
            this.Subject = Subject;
            if(auto)
            {
                this.Icon = "calendar.png";
            } else
            {
                this.Icon = "notepad.png";
            }
            
            this.Datestring = Date.ToString("d");
            this.Auto = auto;

            if (Frequency == "One Time")
            {
                this.DisplayDate = Datestring;
            } else if (Frequency == "Monthly")
            {
                this.DisplayDate = "Every " + GetOrdinalSuffix(Date.Day);    
            } else if (Frequency == "Weekly")
            {
                this.DisplayDate = "Every " + Date.DayOfWeek.ToString();
            } else
            {
                this.DisplayDate = Datestring;
            }


        }
        private static string GetOrdinalSuffix(int num)
        {
            string number = num.ToString();
            if (number.EndsWith("11")) return number + "th";
            if (number.EndsWith("12")) return number + "th";
            if (number.EndsWith("13")) return number + "th";
            if (number.EndsWith("1")) return number + "st";
            if (number.EndsWith("2")) return number + "nd";
            if (number.EndsWith("3")) return number + "rd";
            return number + "th";
        }

    }
}
