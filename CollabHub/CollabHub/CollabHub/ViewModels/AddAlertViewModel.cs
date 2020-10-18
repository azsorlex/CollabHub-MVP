
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

namespace CollabHub.ViewModels
{
    class AddAlertViewModel : BaseViewModel
    {
        public String entryname { get; set; }
        public String subject { get; set; }
        public Boolean onetime { get; set; }
        public Boolean weekly { get; set; }
        public Boolean monthly { get; set; }
        public Boolean daily { get; set; }
        public TimeSpan SelectedTime { get; set; }
        public Xamarin.Forms.Command SubmitAlert { get; set; }

        public AddAlertViewModel()
            
        {
            
            SubmitAlert = new Xamarin.Forms.Command(Submit);

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
                Calendar_Alert toSubmit = new Calendar_Alert(entryname, "1/1/2020", SelectedTime.ToString(), interval, subject.ToString());
                new ToastNotification("Alert added to calendar!", 3000).Show();
                Back();
            }

            
        }

        private async void Back()
        {
            await Shell.Current.GoToAsync("calendar");
        }



    }
}
