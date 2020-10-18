using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using MvvmHelpers;
using CollabHub.Models.GlobalUtilities;
using System.Threading.Tasks;
using Acr.UserDialogs;

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
        public MvvmHelpers.Commands.Command FlipCommand { get; }
        public MvvmHelpers.Commands.Command ChatCommand { get; }
        public MvvmHelpers.Commands.Command BackCommand { get; }


        private ToastNotification notImplemented = new ToastNotification("Not implemented yet.", 1000);


        public VideoViewModel()
        {
            FlipCommand = new MvvmHelpers.Commands.Command(async () => await FlipAction());
            ChatCommand = new MvvmHelpers.Commands.Command(async () => await ChatAction());
            BackCommand = new MvvmHelpers.Commands.Command(async () => await BackAction());
        }

        async Task FlipAction()
        {
            notImplemented.Show();
        }

        async Task ChatAction()
        {
            notImplemented.Show();
        }

        async Task BackAction()
        {
            if (await UserDialogs.Instance.ConfirmAsync("Leave the meeting?", null, "Yes", "No"))
            {
                await Shell.Current.GoToAsync("meeting"); // Return to the meeting page if the user said yes
            }
        }
    }
}