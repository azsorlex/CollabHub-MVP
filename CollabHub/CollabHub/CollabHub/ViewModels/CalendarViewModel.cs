using Xamarin.Forms;
using MvvmHelpers.Commands;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using CollabHub.Views;
using CollabHub.Models;
using System.Linq;
using System.Diagnostics;

namespace CollabHub.ViewModels
{
    class CalendarViewModel : BaseViewModel
    {
        List<Calendar_Table> CalendarMonths { get; set; }
        public List<Calendar_Table.Day> CalendarDays { get; set; }
        public Xamarin.Forms.Command AddAlert { get; set; }
        public Xamarin.Forms.Command ViewAlerts { get; set; }

        public CalendarViewModel()
        {
            AddAlert = new Xamarin.Forms.Command(GoToAddAlert);
            ViewAlerts = new Xamarin.Forms.Command(GoToViewAlerts);
            this.CalendarMonths = new List<Calendar_Table>();
            this.CalendarMonths.Add(new Calendar_Table(1, 2020));
            
            
            Debug.WriteLine(CalendarMonths.First().StartDay.ToString());
            //this.CalendarDays = CalendarMonths.First().DayList;

        }
        async void GoToAddAlert()
        {
            await Shell.Current.GoToAsync("addalert");
        }

        async void GoToViewAlerts()
        {
            await Shell.Current.GoToAsync("viewalerts");
        }
    }
}
