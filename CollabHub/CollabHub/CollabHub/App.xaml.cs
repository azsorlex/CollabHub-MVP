using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CollabHub.Services;
using CollabHub.Views;

namespace CollabHub
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            //MainPage = new HomePage();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
