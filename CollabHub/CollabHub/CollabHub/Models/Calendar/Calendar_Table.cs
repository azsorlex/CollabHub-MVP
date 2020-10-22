using CollabHub.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace CollabHub.Models
{
    public class Calendar_Table
    {

        public int Year { get; set; }
        public int Month { get; set; }
        public int Days { get; set; }
        public int StartDay { get; set; }
        public string MonthName { get; set; }
        //int WeeksCovered { get; set; }
        public List<Calendar_Alert> Alerts { get; set; }
        public Collection<Calendar_Table.Day> DayList { get; set; }

        public Calendar_Table(int month, int year)
        {
            this.Year = year;
            this.Month = month;
            this.StartDay = CalcStartDate(year, month);
            //this.WeeksCovered = CalcWeeksCovered(year, month, StartDay);
            this.DayList = new Collection<Day>();
            this.MonthName = new DateTime(year, month, 1).ToString("MMMM yyyy");

            double count = DateTime.DaysInMonth(year, month) + StartDay;
            count = Math.Ceiling(count / 7) * 7;
            for (int i = 0; i < (int)count; i++)
            {

                this.DayList.Add(new Day(i, this.StartDay, DateTime.DaysInMonth(year, month), month, year));
            }
            
        }

        //static int CalcWeeksCovered(int year, int month, int startday)
        //{
        //    int weeks;
        //    int days = DateTime.DaysInMonth(year, month);
        //    weeks = (days + startday) / 7;
        //    return weeks;
        //}
        static int CalcStartDate(int year, int month)
        {
            List<int> monthconv = new List<int> { 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            double k = 1;
            double m = monthconv[month - 1];
            if (m == 11 || m == 12)
            {
                year -= 1;
            }
            double D = year % 100;
            double C = (year / 100);
            double f = k + Math.Floor((13 * m - 1) / 5) + D + Math.Floor(D / 4) + Math.Floor(C / 4) - 2 * C;
            f %= 7;
            if (f <= 0) { f += 7; }
            return (int)f;
        }

        public class Day
        {

            public string Date { get; set; }
            public DateTime FullDate { get; set; }
            public bool Valid { get; set; }

            public string Color { get; set; }
            
            public Day (int pos, int startday,int daysinmonth, int month, int year) 
            {
                if (pos < startday)
                {
                    this.Valid = false;
                    this.Date = (0).ToString();
                    
                } else if (pos+1 > daysinmonth + startday) {
                    this.Valid = false;
                    this.Date = (0).ToString();
                }else
                {
                    this.Valid = true;
                    int dateint = (pos + 1 - startday);
                    this.FullDate = new DateTime(year, month, dateint);
                    this.Date = dateint.ToString();
                }
                SingletonAlertStore store = SingletonAlertStore.Instance;
                if (store.IsAlert(FullDate))
                {
                    Color = "LimeGreen";
                } else
                {
                    Color = "LightGray";
                }
                
                

            }
        }
    }

}
