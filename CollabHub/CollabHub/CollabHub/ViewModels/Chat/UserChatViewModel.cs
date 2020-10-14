using CollabHub.Models;
using CollabHub.Models.Chat;
using CollabHub.Services;
using CollabHub.Views.Chat;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CollabHub.ViewModels
{
    [QueryProperty("Name", "name")]
    [QueryProperty("Initials", "initials")]
    [QueryProperty("UserColour", "userColour")]


    public class UserChatViewModel : BaseViewModel
    {
        IDataStore<Message> MessageDataStore => DependencyService.Get<IDataStore<Message>>(); 

        // Properties passed from ChatViewModel
        private string name;
        private string initials;
        private string userColour;

        // Text entered by user, saved to database
        private string messageText;

        public Command SaveChat { get; }

        public UserChatViewModel()
        {
            SaveChat = new Command(OnSave);
        }

        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Initials
        {
            get => initials;
            set
            {
                SetProperty(ref initials, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(Initials));
            }
        }

        public string UserColour
        {
            get => userColour;
            set
            {
                SetProperty(ref userColour, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(UserColour));
            }
        }

        public string MessageText
        {
            get => messageText;
            set => SetProperty(ref messageText, value);
        }

        private async void OnSave()
        {
            Message newMessage = new Message()
            {
                Text = messageText
            };

            await MessageDataStore.AddItemAsync(newMessage);
        }

    }
}
