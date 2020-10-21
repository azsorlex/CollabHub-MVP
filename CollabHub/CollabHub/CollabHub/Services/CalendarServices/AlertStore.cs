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
        static IDataStore<Alert> AlertDataStore => DependencyService.Get<IDataStore<Alert>>();
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

        static public List<Calendar_Alert> Alertsold { get
            {
                try
                {
                    var alerts = AlertDataStore.GetItemsAsync(true);
                    List<Calendar_Alert> calendar_alerts = new List<Calendar_Alert>();
                    foreach (Alert i in alerts.Result)
                    {
                        calendar_alerts.Add(new Calendar_Alert(i.Name, i.Date, i.Time, i.Frequency, i.Subject));
                    }

                    return calendar_alerts;
                } catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                return null;

                
            } }
        private string path = "coolfile.txt";
        public List<Calendar_Alert> Alerts2
        {
            get
            {
                System.IO.FileStream file = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
                BinaryFormatter serialiser = new BinaryFormatter();
                List<Calendar_Alert> alerts = (List<Calendar_Alert>)serialiser.Deserialize(file);
                file.Close();
                return alerts;
                
            }
            set
            {
                System.IO.FileStream file = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
                BinaryFormatter serialiser = new BinaryFormatter();
                serialiser.Serialize(file, value);
                file.Close();
            }
        }

        static public bool IsAlert(DateTime date)
        {
            bool yes = false;

            foreach(Calendar_Alert alert in Alerts)
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
