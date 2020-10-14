using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace CollabHub.Models
{
    class Calendar_Table
    {

        public int Year { get; set; }
        public int Month { get; set; }
        public int Days { get; set; }
        public int StartDay { get; set; }
        public int WeeksCovered { get; set; }
        public List<Calendar_Alert> Alerts { get; set; }

        public Calendar_Table(int month, int year)
        {
            this.Year = year;
            this.Month = month;
            this.StartDay = CalcStartDate(year, month);
            this.WeeksCovered = CalcWeeksCovered(year, month, StartDay);
        }

        static int CalcWeeksCovered(int year, int month, int startday)
        {
            int weeks;
            int days = DateTime.DaysInMonth(year, month);
            weeks = (days + startday) / 7;
            return weeks;
        }
        static int CalcStartDate(int year, int month)
        {
            int endday;
            int c = year % 100;
            endday = (int)(1 + Math.Floor((2.6 * month) - 0.2) - (2 * c) + c + Math.Floor((double)c / 4)) % 7;

            return (endday+1) % 7;
        }

        class Day
        {
            public int week;
            public int date;
            public bool valid;
            
            Day (int pos, int startday) 
            {
                if (pos < startday)
                {
                    this.valid = false;
                    return;
                }


            }
        }
    }

}
