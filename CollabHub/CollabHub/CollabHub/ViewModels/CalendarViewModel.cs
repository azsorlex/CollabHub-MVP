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

        public class test
        {
            public string egg { get; set; }
            public test (Int32 val)
            {
                this.egg = val.ToString();
            }
        }

        public ObservableCollection<test> Inties { get; set; }


        public Collection<Calendar_Table.Day> CalendarDays { get; set; }

        List<Calendar_Table> CalendarMonths { get; set; }
        public Xamarin.Forms.Command AddAlert { get; set; }
        public Xamarin.Forms.Command ViewAlerts { get; set; }

        public CalendarViewModel()
        {
            AddAlert = new Xamarin.Forms.Command(GoToAddAlert);
            ViewAlerts = new Xamarin.Forms.Command(GoToViewAlerts);

            this.CalendarMonths = new List<Calendar_Table>();
            this.CalendarMonths.Add(new Calendar_Table(1, 2020));
            
            foreach (Calendar_Table.Day day in CalendarMonths.First().DayList)
            {
                Debug.WriteLine(day.Date);
            }

            CalendarDays = CalendarMonths.First().DayList;

            //Collection<Calendar_Table.Day> DayList = new Collection<Calendar_Table.Day>();
            //DayList.Add(new Calendar_Table.Day(0, 0));
            //DayList.Add(new Calendar_Table.Day(1, 0));
            //DayList.Add(new Calendar_Table.Day(2, 0));
            //DayList.Add(new Calendar_Table.Day(3, 0));

            //try
            //{
            //    foreach (Calendar_Table.Day day in DayList)
            //    {
            //        CalendarDays.Add(day);
            //    }
            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine(e.Message);
            //}


            try
            {
                Inties = new ObservableCollection<test>();
                Inties.Add(new test(3));
                Inties.Add(new test(7));
                Inties.Add(new test(12));
                Inties.Add(new test(10));
            } catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            





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
