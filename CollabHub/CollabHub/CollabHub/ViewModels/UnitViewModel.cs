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
using Xamarin.Forms.Internals;
using Xamarin.Essentials;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CollabHub.ViewModels
{
    class UnitViewModel : BaseViewModel, INotifyPropertyChanged
    {

        private ObservableCollection<SemesterInfo> semesterInfos;
        public Xamarin.Forms.Command IsChanged1 { get; }

        public ObservableCollection<SemesterInfo> SemesterInfos
        {
            get { return semesterInfos; }
            set
            {
                semesterInfos = value;
            }
        }

        public UnitViewModel()
        {
            SetUpInfo();
        }

        void SetUpInfo()
        {
            SemesterInfos = new ObservableCollection<SemesterInfo>();

            SemesterDataStore semesterStore = new SemesterDataStore();

            foreach(var unit in semesterStore.SemesterInfos)
            {
                SemesterInfos.Add(unit);
            }
        }

    }
}
