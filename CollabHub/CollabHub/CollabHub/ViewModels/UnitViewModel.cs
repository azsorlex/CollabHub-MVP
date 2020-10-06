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
    class UnitViewModel : BaseViewModel
    {

        //private ObservableCollection<SemesterInfo> semesterInfos;

        public ObservableCollection<SemesterInfo> SemesterInfos { get; set; }

        public UnitViewModel()
        {
            SetUpInfo();

        }

        void SetUpInfo()
        {
            SemesterInfos = new ObservableCollection<SemesterInfo>()
            {
                new SemesterInfo { SemesterTrack = "Semester 2 2020 (Current)"},
                new SemesterInfo { SemesterTrack = "Semester 1 2020"},
                new SemesterInfo { SemesterTrack = "Semester 2 2019"}
            };
        }
    }
}
