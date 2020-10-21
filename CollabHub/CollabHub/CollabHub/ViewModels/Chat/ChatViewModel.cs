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

        public ChatViewModel()
        {
            Users = new ObservableCollection<User>();

            foreach (var user in UserDataStore.Users)
            {
                Users.Add(user);
            }
        }
    }
}
