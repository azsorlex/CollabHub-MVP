﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CollabHub.Models
{
    class Calendar_Table
    {
        public string Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Days { get; set; }

        public List<Calendar_Alert> Alerts { get; set; }

        public Calendar_Table(string month, int year)
        {
            this.Year = year;
            this.Month = 1;
            this.Days = 30;
            this.Id = "042";
        }
    }
}
