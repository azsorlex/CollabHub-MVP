using CollabHub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollabHub.Services
{
    class SingletonAlertStore
    {
        private static SingletonAlertStore instance = null;

        public List<Calendar_Alert> alerts;
        private SingletonAlertStore() {
            alerts = new List<Calendar_Alert>()
        {
            new Calendar_Alert("Final Exam",new DateTime(2020,1,7),"12:00","One Time","CAB123",true),
            new Calendar_Alert("Assignment 2 Due date",new DateTime(2020,2,6),"03:00","One Time","IFB999",true),
            new Calendar_Alert("Monthly Meeting",new DateTime(2020,1,9),"11:59","Monthly","EGB101",true)

        };
        }

        public static SingletonAlertStore Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonAlertStore();
                }
                return instance;
            }

        }

        static public bool CheckTime(DateTime date, Calendar_Alert alert)
        {
            bool yes = false;
            if (alert.Frequency == "Weekly" && date.DayOfWeek == alert.Date.DayOfWeek)
            {
                yes = true;
            }
            else if (alert.Frequency == "Monthly" && date.Day == alert.Date.Day)
            {
                yes = true;
            }
            else if (alert.Date == date)
            {
                yes = true;
            }
            return yes;
        }

        public bool IsAlert(DateTime date)
        {
            bool yes = false;

            foreach(Calendar_Alert alert in alerts)
            {
                if (CheckTime(date,alert))
                {
                    yes = true;
                }
            }
            return yes;
        }

        public bool IsExactAlert(DateTime date)
        {
            bool yes = false;

            foreach (Calendar_Alert alert in alerts)
            {
                if (alert.Date == date)
                {
                    yes = true;
                }
            }
            return yes;
        }

    }
}
