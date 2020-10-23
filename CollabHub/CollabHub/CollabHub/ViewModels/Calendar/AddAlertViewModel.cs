
using Xamarin.Forms;
using MvvmHelpers.Commands;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using CollabHub.Views;
using System.Threading.Tasks;
using CollabHub.Models;
using System.Diagnostics;
using CollabHub.Models.GlobalUtilities;
using CollabHub.Services;

namespace CollabHub.ViewModels
{
    [QueryProperty("input", "date")]

    class AddAlertViewModel : BaseViewModel
    {
        public string input { set
            {
                string stringdate = Uri.UnescapeDataString(value);
                DateTime properdate = DateTime.Parse(stringdate);
                selectedDate = properdate;
                InDate = properdate.ToString("D");
                OnPropertyChanged(nameof(selectedDate));

                OnPropertyChanged(nameof(InDate));
            } }

        DateTime selectedDate;

        public string InDate { get; set; }
        public string entryname { get; set; }
        public string subject { get; set; }
        public bool onetime { get; set; }
        public bool weekly { get; set; }
        public bool monthly { get; set; }
        public bool daily { get; set; }
        public TimeSpan SelectedTime { get; set; }
        public Xamarin.Forms.Command SubmitAlert { get; set; }

        public AddAlertViewModel()
            
        {
            
            SubmitAlert = new Xamarin.Forms.Command(Submit);
            //InDate = "testing";

        }
        void Submit()
        {
            String interval;

            if (onetime)
            {
                interval = "One Time";
            }
            else if (weekly)
            {
                interval = "Weekly";
            }
            else if (monthly)
            {
                interval = "Monthly";
            }
            else if (daily)
            {
                interval = "Daily";
            }
            else
            {
                interval = "error";

            }

            if (entryname == "")
            {
                new ToastNotification("Please select an alert title.", 3000).Show();
            } else if (subject == "")
            {
                new ToastNotification("Please select an alert subject.", 3000).Show();
            } else if (interval == "error") 
            {
                new ToastNotification("Please select an alert interval.", 3000).Show();
            } else
            {
                Debug.WriteLine(entryname.ToString());
                Debug.WriteLine(subject.ToString());
                Debug.WriteLine(interval.ToString());
                Debug.WriteLine(SelectedTime.ToString());
                Debug.WriteLine(selectedDate.ToString("d"));
                DateTime temp = DateTime.Today.Add(SelectedTime);

                Calendar_Alert toSubmit = new Calendar_Alert(entryname, selectedDate, temp.ToString("hh:mm tt"), interval, subject.ToString());

                SingletonAlertStore store = SingletonAlertStore.Instance;
                store.alerts.Add(toSubmit);
                new ToastNotification("Alert added to calendar!", 3000).Show();
                Back();
            }

            
        }

        private async void Back()
        {
            await Shell.Current.GoToAsync("calendar");
            Shell.Current.Navigation.RemovePage(Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2]);
            Shell.Current.Navigation.RemovePage(Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 3]);

        }



    }
}
