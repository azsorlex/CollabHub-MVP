using System;
using System.Collections.Generic;
using System.Text;
using CollabHub.Models;
namespace CollabHub.Services
{
    class AlertStore
    {
        public List<Calendar_Alert> Alerts = new List<Calendar_Alert>()
        {
            new Calendar_Alert("Urgent","1/2/2020","12:00"),
            new Calendar_Alert("Not so Urget","5/6/2021","03:00"),
            new Calendar_Alert("Meh","6/9/2030","11:59")

        };

    }
}
