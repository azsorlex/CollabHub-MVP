using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using MvvmHelpers;
using CollabHub.Models.GlobalUtilities;
using System.Threading.Tasks;
using Acr.UserDialogs;
using System.Collections.ObjectModel;
using CollabHub.Models.Chat;
using System.Diagnostics;
using CollabHub.Services;

namespace CollabHub.ViewModels
{
    [QueryProperty("UnitCode", "unitcode")]
    class VideoViewModel : BaseViewModel
    {
        public ObservableCollection<Message> Messages { get; set; }
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
        private string _messagetext;
        public string MessageText
        {
            get => _messagetext;
            set => SetProperty(ref _messagetext, value);
        }
        private bool _chatVisible;
        public bool ChatVisible
        {
            get => _chatVisible;
            set => SetProperty(ref _chatVisible, value);
        }

        public MvvmHelpers.Commands.Command FlipCommand { get; }
        public MvvmHelpers.Commands.Command ChatCommand { get; }
        public MvvmHelpers.Commands.Command SaveChatCommand { get; }
        public MvvmHelpers.Commands.Command BackCommand { get; }


        private readonly ToastNotification notImplemented = new ToastNotification("Not implemented yet.", 1000);


        public VideoViewModel()
        {
            Messages = new ObservableCollection<Message>();
            ChatVisible = false;

            FlipCommand = new MvvmHelpers.Commands.Command(async () => await FlipAction());
            ChatCommand = new MvvmHelpers.Commands.Command(async () => await ChatAction());
            SaveChatCommand = new MvvmHelpers.Commands.Command(async () => await SaveChatAction());
            BackCommand = new MvvmHelpers.Commands.Command(async () => await BackAction());
        }

        async Task FlipAction()
        {
            notImplemented.Show();
        }

        async Task ChatAction()
        {
            ChatVisible = !ChatVisible;
        }

        async Task SaveChatAction()
        {
            await Task.Run(() =>
            {
                Message m = new Message()
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = MessageText,
                    Timestamp = DateTime.Now.ToString("dd/MM/yyyy HH:mmtt"),
                    To = "",
                    From = UserDataStore.CurrentUser.Name
                };

                Messages.Add(m);

                MessageText = "";
            });
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