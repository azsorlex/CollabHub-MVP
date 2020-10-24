using CollabHub.Models.Chat;
using CollabHub.Models;
using CollabHub.Services;
using MvvmHelpers;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CollabHub.ViewModels
{
    public class ChangeUserViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }

        public Command ChangeUserCommand { get; }

        public string CurrentUser { get; set; }

        User user;

        public User SelectedUser
        {
            get => user;
            set
            {
                SetProperty(ref user, value);
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        public ChangeUserViewModel()
        {
            PopulateUsers();
            CurrentUser = UserDataStore.CurrentUser.Name;
            ChangeUserCommand = new Command(ChangeUser);
        }

        void PopulateUsers()
        {
            Users = new ObservableCollection<User>();

            foreach (var user in UserDataStore.Users)
            {
                Users.Add(user);
            }
        }

        async void ChangeUser()
        {
            if (IsBusy) return;

            if (SelectedUser != null)
            {
                try
                {
                    IsBusy = true;

                    int index = -1;

                    index = UserDataStore.Users.FindIndex(u => u.Name.Equals(SelectedUser.Name));

                    if (index != -1)
                    {
                        // Add current 'logged in' user to static List<User> so they appear in chat view
                        UserDataStore.Users.Add(UserDataStore.CurrentUser);
                        //  Change current user to selected user in static UserDataStore
                        UserDataStore.CurrentUser = UserDataStore.Users[index];
                        //  Remove this user so their own profile does not appear in list of recipients
                        UserDataStore.Users.RemoveAt(index);
                        // Change view to Home to update greeting message
                        await Shell.Current.GoToAsync("home");
                    }

                    SelectedUser = null;
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error!", ex.Message + "Selected Contact Value = " + SelectedUser.Name, "OK");
                }
                finally
                {
                    IsBusy = false;
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please select a user or return to the Home page", "OK");
                return;
            }
        }
    }
}
