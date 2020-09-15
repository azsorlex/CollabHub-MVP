using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CollabHub_MVP.Services;
using CollabHub_MVP.Views;

namespace CollabHub_MVP
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
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
