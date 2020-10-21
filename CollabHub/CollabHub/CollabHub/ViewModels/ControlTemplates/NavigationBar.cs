
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using CollabHub.Models;
using CollabHub.Services;
using CollabHub.Views;
using Acr.UserDialogs;
using System.Linq;

namespace CollabHub.ViewModels.ControlTemplates
{
    class NavigationBar : ContentView
    {
        public Command HomePage { get; set; }

        public Command ChangeUser { get; set; }

        public static readonly BindableProperty PageNameProperty = BindableProperty.Create(nameof(PageName), typeof(string), typeof(NavigationBar), string.Empty);

        public string PageName
        {
            get => (string)GetValue(PageNameProperty);
            set => SetValue(PageNameProperty, value);
        }

        public NavigationBar()
        {
            HomePage = new Command(GoToHomePage);
            ChangeUser = new Command(SwitchUserTest);
        }

        //  Currently not working as intended - Work in progress.
        private void SwitchUserTest()
        {
            int found = UserDataStore.Users.FindIndex(u => u.Id == UserDataStore.CurrentUser[0].Id);

            if (found != 0)
            {
                UserDataStore.Users.Add(UserDataStore.CurrentUser[0]);
                UserDataStore.CurrentUser[0] = UserDataStore.Users[0];
            }
        }

        private async void GoToHomePage()
        {
            await Shell.Current.GoToAsync("home");
        }
    }
}
