
using Xamarin.Forms;
using MvvmHelpers.Commands;
using MvvmHelpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Text;
using CollabHub.Views;
using CollabHub.Models;
using CollabHub.Services;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollabHub.ViewModels
{
    [QueryProperty("selected", "select")]
    class ViewAlertsViewModel : BaseViewModel
    {
        private ObservableCollection<Calendar_Alert> alerts;

        public Xamarin.Forms.Command ItemPress { get; set; }

        public string selected {  set
            {
                DateTime selecteddate = DateTime.Parse(Uri.UnescapeDataString(value));
                SingletonAlertStore store = SingletonAlertStore.Instance;
                Calendar_Alert selectedalert = store.alerts.Find(x => x.Date == selecteddate);
                Debug.WriteLine(selectedalert.Datestring);

                Selection = selectedalert;
                OnPropertyChanged(nameof(Selection));
                Debug.WriteLine("yas");
            }
        }

        public Calendar_Alert Selection { get; set; }

        public ObservableCollection<Calendar_Alert> Alerts
        {
            get { return alerts; }
            set
            {
                alerts = value;
            }
        }

        public ViewAlertsViewModel()
        {
            
            Alerts = new ObservableCollection<Calendar_Alert>();

            //AlertStore store = new AlertStore();
            SingletonAlertStore store = SingletonAlertStore.Instance;

            foreach (var al in store.alerts)
            {
                Alerts.Add(al);
            }

            ItemPress = new Xamarin.Forms.Command<string>(DeletePrompt);
        }

        async void DeletePrompt(string i)
        {
            Debug.WriteLine("yos queen");
            Calendar_Alert selected = SingletonAlertStore.Instance.alerts.Find(x => x.Datestring == i);
            bool delete = await Shell.Current.DisplayAlert(selected.Name, "Do you want to delete this alert?", "Delete", "Cancel");
            if (delete)
            {
                SingletonAlertStore.Instance.alerts.Remove(selected);
                Alerts.Remove(selected);

            }

            
        }

        
        


    }
}
