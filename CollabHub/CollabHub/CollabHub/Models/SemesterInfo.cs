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

        public bool _isExpandSwitch;

        public bool IsExpandSwitch
        {
            get { return _isExpandSwitch; }

            set
            {
                _isExpandSwitch = value;
                OnPropertyChanged("IsExpandSwitch");
            }
        }

        public bool IsExpandDown1_1 { get; set; }
        public bool IsExpandSide1_1 { get; set; } = true;

        public ICommand CheckExpand1_1
        {
            get
            {
                return new Command(() =>
               {
                   IsExpandDown1_1 = !IsExpandDown1_1;
                   IsExpandSide1_1 = !IsExpandDown1_1;
                   OnPropertyChanged("IsExpandDown1_1");
                   OnPropertyChanged("IsExpandSide1_1");
               });
            }
        }

        public bool IsExpandDown1_2 { get; set; }
        public bool IsExpandSide1_2 { get; set; } = true;

        public ICommand CheckExpand1_2
        {
            get
            {
                return new Command(() =>
                {
                    IsExpandDown1_2 = !IsExpandDown1_2;
                    IsExpandSide1_2 = !IsExpandDown1_2;
                    OnPropertyChanged("IsExpandDown1_2");
                    OnPropertyChanged("IsExpandSide1_2");
                });
            }
        }

        public bool IsExpandDown1_3 { get; set; }
        public bool IsExpandSide1_3 { get; set; } = true;
        public ICommand CheckExpand1_3
        {
            get
            {
                return new Command(() =>
                {
                    IsExpandDown1_3 = !IsExpandDown1_3;
                    IsExpandSide1_3 = !IsExpandDown1_3;
                    OnPropertyChanged("IsExpandDown1_3");
                    OnPropertyChanged("IsExpandSide1_3");
                });
            }
        }

        public bool IsExpandDown2_1 { get; set; }
        public bool IsExpandSide2_1 { get; set; } = true;

        public ICommand CheckExpand2_1
        {
            get
            {
                return new Command(() =>
                {
                    IsExpandDown2_1 = !IsExpandDown2_1;
                    IsExpandSide2_1 = !IsExpandDown2_1;
                    OnPropertyChanged("IsExpandDown2_1");
                    OnPropertyChanged("IsExpandSide2_1");
                });
            }
        }

        public bool IsExpandDown2_2 { get; set; }
        public bool IsExpandSide2_2 { get; set; } = true;

        public ICommand CheckExpand2_2
        {
            get
            {
                return new Command(() =>
                {
                    IsExpandDown2_2 = !IsExpandDown2_2;
                    IsExpandSide2_2 = !IsExpandDown2_2;
                    OnPropertyChanged("IsExpandDown2_2");
                    OnPropertyChanged("IsExpandSide2_2");
                });
            }
        }

        public bool IsExpandDown2_3 { get; set; }
        public bool IsExpandSide2_3 { get; set; } = true;
        public ICommand CheckExpand2_3
        {
            get
            {
                return new Command(() =>
                {
                    IsExpandDown2_3 = !IsExpandDown2_3;
                    IsExpandSide2_3 = !IsExpandDown2_3;
                    OnPropertyChanged("IsExpandDown2_3");
                    OnPropertyChanged("IsExpandSide2_3");
                });
            }
        }


        public bool IsExpandDown3_1 { get; set; }
        public bool IsExpandSide3_1 { get; set; } = true;

        public ICommand CheckExpand3_1
        {
            get
            {
                return new Command(() =>
                {
                    IsExpandDown3_1 = !IsExpandDown3_1;
                    IsExpandSide3_1 = !IsExpandDown3_1;
                    OnPropertyChanged("IsExpandDown3_1");
                    OnPropertyChanged("IsExpandSide3_1");
                });
            }
        }

        public bool IsExpandDown3_2 { get; set; }
        public bool IsExpandSide3_2 { get; set; } = true;

        public ICommand CheckExpand3_2
        {
            get
            {
                return new Command(() =>
                {
                    IsExpandDown3_2 = !IsExpandDown3_2;
                    IsExpandSide3_2 = !IsExpandDown3_2;
                    OnPropertyChanged("IsExpandDown3_2");
                    OnPropertyChanged("IsExpandSide3_2");
                });
            }
        }

        public bool IsExpandDown3_3 { get; set; }
        public bool IsExpandSide3_3 { get; set; } = true;
        public ICommand CheckExpand3_3
        {
            get
            {
                return new Command(() =>
                {
                    IsExpandDown3_3 = !IsExpandDown3_3;
                    IsExpandSide3_3 = !IsExpandDown3_3;
                    OnPropertyChanged("IsExpandDown3_3");
                    OnPropertyChanged("IsExpandSide3_3");
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
