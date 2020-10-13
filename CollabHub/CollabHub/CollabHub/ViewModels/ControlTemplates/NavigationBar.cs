
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using CollabHub.Models;

namespace CollabHub.ViewModels.ControlTemplates
{
    class NavigationBar : ContentView
    {
        public Command HomePage { get; set; }

        public static readonly BindableProperty PageNameProperty = BindableProperty.Create(nameof(PageName), typeof(string), typeof(NavigationBar), string.Empty);

        public string PageName
        {
            get => (string)GetValue(PageNameProperty);
            set => SetValue(PageNameProperty, value);
        }

        public NavigationBar()
        {
            HomePage = new Command(GoToHomePage);
        }

        private async void GoToHomePage()
        {
            await Shell.Current.GoToAsync("home");
        }
    }
}
