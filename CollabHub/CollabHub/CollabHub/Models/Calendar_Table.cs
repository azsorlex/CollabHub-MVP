using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CollabHub.Models
{
    class Calendar_Table
    {

        public int Year { get; set; }
        public int Month { get; set; }
        public int Days { get; set; }
        public List<Calendar_Alert> Alerts { get; set; }

        public Calendar_Table(int month, int year)
        {
            this.Year = year;
            this.Month = month;

        }
    }
}
