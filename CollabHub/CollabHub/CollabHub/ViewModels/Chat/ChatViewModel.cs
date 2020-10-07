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
using System.Windows.Input;

namespace CollabHub.ViewModels
{
    class ChatViewModel : BaseViewModel
    {
        private ObservableCollection<User> users;

        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
            }
        }

        public Xamarin.Forms.Command UserChatPage { get; set; }

        public ChatViewModel()
        {
            UserChatPage = new Xamarin.Forms.Command(GoToUserChatPage);

            Users = new ObservableCollection<User>();

            UserDataStore userStore = new UserDataStore();

            foreach (var user in userStore.Users)
            {
                Users.Add(user);
            }
        }

        async void GoToUserChatPage()
        {
            await Shell.Current.GoToAsync("userChat");
        }
    }
}
