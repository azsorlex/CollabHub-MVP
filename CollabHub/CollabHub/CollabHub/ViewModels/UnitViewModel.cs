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

namespace CollabHub.ViewModels
{
    class UnitViewModel : BaseViewModel
    {

        private ObservableCollection<SemesterInfo> semesterInfos;

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
