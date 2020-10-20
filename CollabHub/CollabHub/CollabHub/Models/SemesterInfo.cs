using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CollabHub.Models
{
    public class SemesterInfo : INotifyPropertyChanged
    {
        public string SemesterTrack { get; set; }
        public List<String> UnitContentHeading { get; set; }
        public List<String> UnitCode { get; set; }
        public List<String> Unit1UnitInfo { get; set; }
        public List<String> Unit1LearningMat { get; set; }
        public List<String> Unit1AssessmentT { get; set; }

        public bool _isExpand;

        public bool IsExpand
        {
            get => _isExpand;

            set
            {
                _isExpand = value;
                OnPropertyChanged("IsExpand");
            }
        }

        public bool Testw;
        public ICommand Testh
        {
            get
            {
                return new Command(() =>
               {
                   Testw = !Testw;
               });
            }
        }

        //public ICommand TestHey { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
