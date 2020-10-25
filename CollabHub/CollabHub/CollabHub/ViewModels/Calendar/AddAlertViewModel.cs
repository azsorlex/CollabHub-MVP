
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
        IDataStore<Alert> AlertDataStore => DependencyService.Get<IDataStore<Alert>>();
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
        public TimeSpan SelectedTime { get; set; }
        public Xamarin.Forms.Command SubmitAlert { get; set; }

        public AddAlertViewModel()
            
        {
            
            SubmitAlert = new Xamarin.Forms.Command(Submit);
            CancelAlert = new Xamarin.Forms.Command(Cancel);
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
                bool unique = true;
                foreach(Calendar_Alert alert in SingletonAlertStore.Instance.alerts)
                {
                    if(alert.Name == entryname.ToString())
                    {
                        unique = false;
                    }
                }
                if (unique)
                {
                    Debug.WriteLine(entryname.ToString());
                    Debug.WriteLine(subject.ToString());
                    Debug.WriteLine(interval.ToString());
                    Debug.WriteLine(SelectedTime.ToString());
                    Debug.WriteLine(selectedDate.ToString("d"));
                    DateTime temp = DateTime.Today.Add(SelectedTime);

                    Calendar_Alert toSubmit = new Calendar_Alert(entryname, selectedDate, temp.ToString("hh:mm tt"), interval, subject.ToString(), false);

                    //Alert newalert = new Alert()
                    //{
                    //    Name = entryname,
                    //    Date = selectedDate,
                    //    Frequency = interval,
                    //    Subject = subject,
                    //    Time = temp.ToString("hh:mm tt"),
                    //    Automatic = false

                    //};

                    //SingletonAlertStore.Instance.AlertDataStore.AddItemAsync(newalert);



                    SingletonAlertStore store = SingletonAlertStore.Instance;
                    store.alerts.Add(toSubmit);
                    new ToastNotification("Alert added to calendar!", 3000).Show();
                    Back();
                } else
                {
                    new ToastNotification("That name has already been used. Please select another", 3000).Show();
                }
                
            }

            
        }
        public Xamarin.Forms.Command CancelAlert { get; set; }
        public async void Cancel()
        {
            bool cancel = await Shell.Current.DisplayAlert("Cancel", "Are you sure you want to cancel creating this alert?", "Yes", "No");
            if(cancel)
            {
                await Shell.Current.Navigation.PopAsync();
            }
            
        }

        private async void Back()
        {
            await Shell.Current.GoToAsync("calendar");
            Page a = Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2];
            Page b = Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 3];
            Shell.Current.Navigation.RemovePage(a);
            Shell.Current.Navigation.RemovePage(b);

        }



    }
}
