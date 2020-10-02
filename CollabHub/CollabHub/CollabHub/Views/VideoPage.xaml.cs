using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CollabHub.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollabHub.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPage : ContentPage
    {
        public VideoPage()
        {
            InitializeComponent();

            UpdateEvents();

            // Start a timer that activates every minute
            Device.StartTimer(new TimeSpan(0, 1, 0), () =>
            {
                UpdateEvents();
                return true;
            });
        }

        // Update what is seen to the user
        private void UpdateEvents()
        {
            var vm = BindingContext as VideoViewModel;

            meetingList.ItemsSource = null;
            meetingList.ItemsSource = vm.Meetings;
        }

        // When an item is tapped, update the items' commands so that the decicion is correct
        private void Tapped(object sender, EventArgs e)
        {
            var vm = BindingContext as VideoViewModel;

            for (int i = 0; i < vm.Meetings.Count; i++)
            {
                vm.Meetings[i].TapCommand = vm.OnTapped(i);
            }

            UpdateEvents();
        }
    }
}