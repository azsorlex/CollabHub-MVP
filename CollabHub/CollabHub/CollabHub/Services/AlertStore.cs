using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using CollabHub.Models;
namespace CollabHub.Services
{
    class AlertStore
    {

        public AlertStore()
        {
            //Alerts2 = Alerts;
        }
        public List<Calendar_Alert> Alerts = new List<Calendar_Alert>()
        {
            new Calendar_Alert("Urgent","1/2/2020","12:00"),
            new Calendar_Alert("Not so Urget","5/6/2021","03:00"),
            new Calendar_Alert("Meh","6/9/2030","11:59")

        };
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

        
            

    }
}
