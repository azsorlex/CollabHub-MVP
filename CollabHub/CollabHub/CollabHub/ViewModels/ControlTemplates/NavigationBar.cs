
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using CollabHub.Models;
using CollabHub.Services;
using CollabHub.Views;
using Acr.UserDialogs;
using System.Linq;
using CollabHub.Views.Chat;

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
            ChangeUser = new Command(GoToChangeUser);
            //ChangeUser = new Command(SwitchUserTest);

        }

        private async void GoToHomePage()
        {
            await Shell.Current.Navigation.PopToRootAsync();
            //await Shell.Current.GoToAsync("home",false);
        }

        private async void GoToChangeUser()
        {
            await Shell.Current.GoToAsync("changeUser");
        }
    }
}
