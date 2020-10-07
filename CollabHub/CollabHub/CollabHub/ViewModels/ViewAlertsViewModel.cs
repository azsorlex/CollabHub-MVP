
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

namespace CollabHub.ViewModels
{
    class ViewAlertsViewModel : BaseViewModel
    {
        private ObservableCollection<Calendar_Alert> alerts;

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

            AlertStore store = new AlertStore();

            foreach(var al in store.Alerts)
            {
                Alerts.Add(al);
            }
        }

    }
}
