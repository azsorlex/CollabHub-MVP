using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using CollabHub.Models;
using Xamarin.Forms;

namespace CollabHub.Services
{
    class AlertStore
    {
        public AlertStore()
        {
            //Alerts2 = Alerts;
        }
        static public List<Calendar_Alert> Alerts = new List<Calendar_Alert>()
        {
            new Calendar_Alert("Urgent",new DateTime(2020,1,6),"12:00","Weekly","EGBnan"),
            new Calendar_Alert("Not so Urget",new DateTime(2021,5,6),"03:00","Daily","IFB333"),
            new Calendar_Alert("Meh",new DateTime(2030,6,9),"11:59","Monthly","IFB963")

        };



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


        static public bool IsAlert(DateTime date)
        {
            bool yes = false;

            foreach(Calendar_Alert alert in Alerts)
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
