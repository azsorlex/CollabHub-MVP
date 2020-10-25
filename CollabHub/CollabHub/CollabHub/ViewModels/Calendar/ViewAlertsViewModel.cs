
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
using System.Linq;

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
                Calendar_Alert selectedalert = store.alerts.Find(x => SingletonAlertStore.CheckTime(selecteddate,x));
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

        public ObservableCollection<Calendar_Alert> PersonalAlerts { get; set; }
        public ObservableCollection<Calendar_Alert> AllAlerts { get; set; }

        public ViewAlertsViewModel()
        {
            ViewText = "All Alerts";
            Alerts = new ObservableCollection<Calendar_Alert>();
            PersonalAlerts = new ObservableCollection<Calendar_Alert>();
            AllAlerts = new ObservableCollection<Calendar_Alert>();

            //AlertStore store = new AlertStore();
            SingletonAlertStore store = SingletonAlertStore.Instance;

            foreach (var al in store.alerts)
            {
                Alerts.Add(al);
                AllAlerts.Add(al);
                if (!al.Auto)
                {
                    PersonalAlerts.Add(al);
                }
            }

            ItemPress = new Xamarin.Forms.Command<string>(DeletePrompt);
            ShowAll = new Xamarin.Forms.Command(ShowAllAlerts);
            ShowPersonal = new Xamarin.Forms.Command(ShowPersonalAlerts);
            GoBack = new Xamarin.Forms.Command(BackButton);
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
                AllAlerts.Remove(selected);
                PersonalAlerts.Remove(selected);

                Shell.Current.Navigation.RemovePage(Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2]);
                Shell.Current.Navigation.InsertPageBefore(new CalendarPage(), Shell.Current.Navigation.NavigationStack.Last());

            }

            
        }

        public string ViewText { get; set; }
        public Xamarin.Forms.Command ShowPersonal { get; set; }
        public Xamarin.Forms.Command ShowAll { get; set; }
        public Xamarin.Forms.Command GoBack { get; set; }

        void ShowPersonalAlerts()
        {
            ViewText = "Personal Alerts";
            OnPropertyChanged(nameof(ViewText));
            Alerts = PersonalAlerts;
            OnPropertyChanged(nameof(Alerts));
        }

        void ShowAllAlerts()
        {
            ViewText = "All Alerts";
            OnPropertyChanged(nameof(ViewText));
            Alerts = AllAlerts;
            OnPropertyChanged(nameof(Alerts));
        }

        async void BackButton()
        {
            await Shell.Current.Navigation.PopAsync();
        }
        
        


    }
}
