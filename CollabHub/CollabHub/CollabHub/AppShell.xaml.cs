using CollabHub.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace CollabHub
{
    public partial class AppShell : Xamarin.Forms.Shell
    {

        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        void RegisterRoutes()
        {
            routes.Add("units", typeof(UnitPage));
            routes.Add("calendar", typeof(CalendarPage));
            routes.Add("chat", typeof(ChatPage));
            routes.Add("video", typeof(VideoPage));
            routes.Add("home", typeof(HomePage));
            routes.Add("addalert", typeof(AddAlert));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}
