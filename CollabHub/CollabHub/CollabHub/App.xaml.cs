using System;
using Xamarin.Forms;
using CollabHub.Models.GlobalUtilities;
using CollabHub.Services;
using CollabHub.Models;

namespace CollabHub
{
    public partial class App : Application
    {
        static AppDatabase database;

        public static AppDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new AppDatabase();
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep() // Pause the currently running timer when the app gets minimised, such as when pressing the home button
        {
            StoppableTimer.Stop(false);
        }

        protected override void OnResume() // Resume the timer
        {
            if (StoppableTimer.timerInfo != null)
                StoppableTimer.Start((TimeSpan)StoppableTimer.timerInfo[0], (Action)StoppableTimer.timerInfo[1]);
        }
    }
}
