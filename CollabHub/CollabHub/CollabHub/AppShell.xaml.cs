using CollabHub.Views;
using CollabHub.Views.Chat;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        
        protected override bool OnBackButtonPressed()
        {
            ////Shell.Current.GetType() == typeof(ViewAlerts)
            //IReadOnlyList<Page> temp = Shell.Current.Navigation.NavigationStack;
            //if(temp.Count != 0 && temp.Count > 2)
            //{
            //    if (temp.Last().Title == "viewalerts" && temp.Last().)
            //    {

            //        Shell.Current.Navigation.RemovePage(temp[temp.Count - 2]);
            //        Shell.Current.Navigation.InsertPageBefore(new CalendarPage(), temp.Last());
            //        Debug.WriteLine("yo we here");
                    
            //        // new CalendarPage();
            //    }
            //}
            
            return base.OnBackButtonPressed();
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
            Routes.Add("changeUser", typeof(ChangeUserModalPage));
            Routes.Add("addalert", typeof(AddAlert));
            Routes.Add("viewalerts", typeof(ViewAlerts));

            foreach (var item in Routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}
