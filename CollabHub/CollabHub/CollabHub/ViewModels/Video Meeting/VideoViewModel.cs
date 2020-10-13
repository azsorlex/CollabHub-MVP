using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using MvvmHelpers;
using CollabHub.Models.GlobalUtilities;

namespace CollabHub.ViewModels
{
    [QueryProperty("UnitCode", "unitcode")]
    class VideoViewModel : BaseViewModel
    {
        private string _unitcode;
        public string UnitCode
        {
            get => _unitcode;
            set
            {
                SetProperty(ref _unitcode, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(UnitCode));
            }
        }

        public VideoViewModel()
        {
            new ToastNotification("Work in progress :)", 10000).Show();
        }
    }
}