using CollabHub.Models.Chat;
using CollabHub.Services;
using MvvmHelpers;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CollabHub.ViewModels
{
    [QueryProperty("Name", "name")]
    [QueryProperty("FirstName", "firstName")]
    [QueryProperty("Initials", "initials")]
    [QueryProperty("UserColour", "userColour")]


    public class UserChatViewModel : BaseViewModel
    {
        IDataStore<Message> MessageDataStore => DependencyService.Get<IDataStore<Message>>(); 

        public ObservableCollection<Message> Messages { get; }

        // Properties passed from ChatViewModel
        private string name;
        private string firstName;
        private string initials;
        private string userColour;

        // Text entered by user, saved to database
        private string messageText;

        public Command SaveChat { get; }

        public Command LoadItemsCommand { get; }

        public UserChatViewModel()
        {
            SaveChat = new Command(OnSave);
            Messages = new ObservableCollection<Message>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(Name));
            }
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                SetProperty(ref firstName, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string Initials
        {
            get => initials;
            set
            {
                SetProperty(ref initials, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(Initials));
            }
        }

        public string UserColour
        {
            get => userColour;
            set
            {
                SetProperty(ref userColour, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(UserColour));
            }
        }

        public string MessageText
        {
            get => messageText;
            set => SetProperty(ref messageText, value);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Messages.Clear();
                var messages = await MessageDataStore.GetItemsAsync(true);
                foreach(var message in messages)
                {
                    Messages.Add(message);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnSave()
        {
            Message newMessage = new Message()
            {
                Id = Guid.NewGuid().ToString(),
                Text = messageText
            };

            await App.Current.MainPage.DisplayAlert("Alert", newMessage.Text, "OK");

            await MessageDataStore.AddItemAsync(newMessage);
        }

    }
}
