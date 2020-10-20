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
using System.Collections.ObjectModel;

namespace CollabHub.ViewModels
{
    class CalendarViewModel : BaseViewModel
    {

        public string Date { get; set; }

        public Collection<Calendar_Table.Day> CalendarDays { get; set; }

        public List<Calendar_Table> CalendarMonths { get; set; }
        public Xamarin.Forms.Command AddAlert { get; set; }
        public Xamarin.Forms.Command ViewAlerts { get; set; }

        public CalendarViewModel()
        {
            AddAlert = new Xamarin.Forms.Command<string>(GoToAddAlert);
            ViewAlerts = new Xamarin.Forms.Command(GoToViewAlerts);

            CalendarMonths = new List<Calendar_Table>();
            CalendarMonths.Add(new Calendar_Table(1, 2020));
            CalendarMonths.Add(new Calendar_Table(2, 2020));

            //foreach (Calendar_Table.Day day in CalendarMonths.First().DayList)
            //{
            //    Debug.WriteLine(day.Date);
            //}

            CalendarDays = CalendarMonths.First().DayList;

            Date = DateTime.Today.ToString();


        }
        async void GoToAddAlert(string i)
        {
            await Shell.Current.GoToAsync($"addalert?date={i}");
        }

        async void GoToViewAlerts()
        {
            await Shell.Current.GoToAsync("viewalerts");
        }
    }
}
