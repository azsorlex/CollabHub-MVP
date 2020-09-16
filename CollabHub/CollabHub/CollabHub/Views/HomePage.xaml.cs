using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollabHub.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage  (new UnitPage()));
        }

        async void NavigateButton_OnCalendarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new CalendarPage()));
        }
    }
}