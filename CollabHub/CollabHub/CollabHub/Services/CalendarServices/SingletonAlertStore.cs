﻿using CollabHub.Models;
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
            new Calendar_Alert("Urgent",new DateTime(2020,1,6),"12:00","Weekly","EGBnan"),
            new Calendar_Alert("Not so Urget",new DateTime(2021,5,6),"03:00","Daily","IFB333"),
            new Calendar_Alert("Meh",new DateTime(2030,6,9),"11:59","Monthly","IFB963")

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

        public bool IsAlert(DateTime date)
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
