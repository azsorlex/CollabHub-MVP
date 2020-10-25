using CollabHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace CollabHub.Services
{
    class SingletonAlertStore
    {
        public IDataStore<Alert> AlertDataStore => DependencyService.Get<IDataStore<Alert>>();
        private static SingletonAlertStore instance = null;

        public List<Calendar_Alert> alerts;
        private SingletonAlertStore() {
            
            alerts = new List<Calendar_Alert>();
            //Database.CreateTablesAsync(CreateFlags.None, typeof(Alert)).ConfigureAwait(false);

            //if (AlertDataStore.GetItemsAsync().Result.Count() == 0)
            //{
            //    AlertDataStore.AddItemAsync(ConvertAlert(new Calendar_Alert("Urgent", new DateTime(2020, 1, 6), "12:00", "Weekly", "EGBnan", true)));
            //    AlertDataStore.AddItemAsync(ConvertAlert(new Calendar_Alert("Not so Urgent", new DateTime(2021, 5, 6), "03:00", "Daily", "IFB333", true)));
            //    AlertDataStore.AddItemAsync(ConvertAlert(new Calendar_Alert("Meh", new DateTime(2030, 6, 9), "11:59", "Monthly", "IFB963", true)));
            //}

            Starup();
            //System.Threading.Thread.Sleep(5000);

            //await MessageDataStore.AddItemAsync(newMessage);
        }

        private async void Starup()
        {
            var messages = await AlertDataStore.GetItemsAsync(true);
            foreach (Alert i in messages)
            {
                alerts.Add(new Calendar_Alert(i.Name, i.Date, i.Time, i.Frequency, i.Subject, i.Automatic));
            }
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

        public static Alert ConvertAlert(Calendar_Alert alert)
        {
            Alert newalert = new Alert()
            {
                Name = alert.Name,
                Date = alert.Date,
                Frequency = alert.Frequency,
                Subject = alert.Subject,
                Time = alert.Time,
                Automatic = alert.Auto

            };

            return newalert;
        }

    }
}
