using CollabHub.Views;
using System;
using System.Collections.Generic;

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
        }

        void RegisterRoutes()
        {
            routes.Add("about", typeof(AboutPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}
