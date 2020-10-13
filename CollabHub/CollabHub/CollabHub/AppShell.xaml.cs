using CollabHub.Views;
using CollabHub.Views.Chat;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CollabHub
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; } = new Dictionary<string, Type>();
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        void RegisterRoutes()
        {
            Routes.Add("units", typeof(UnitPage));
            Routes.Add("calendar", typeof(CalendarPage));
            Routes.Add("chat", typeof(ChatPage));
            Routes.Add("userChat", typeof(UserChat));
            Routes.Add("meeting", typeof(MeetingPage));
            Routes.Add("video", typeof(VideoPage));
            Routes.Add("home", typeof(HomePage));
            Routes.Add("addalert", typeof(AddAlert));
            Routes.Add("viewalerts", typeof(ViewAlerts));

            foreach (var item in Routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}
