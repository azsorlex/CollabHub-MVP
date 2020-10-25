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
            new Calendar_Alert("Urgent",new DateTime(2020,1,6),"12:00","Weekly","EGBnan",true),
            new Calendar_Alert("Not so Urgent",new DateTime(2021,5,6),"03:00","Daily","IFB333",true),
            new Calendar_Alert("Meh",new DateTime(2030,6,9),"11:59","Monthly","IFB963",true)

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

    }
}
