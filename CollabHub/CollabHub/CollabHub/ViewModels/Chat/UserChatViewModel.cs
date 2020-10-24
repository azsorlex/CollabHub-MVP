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
    [QueryProperty("Name", "name")]
    [QueryProperty("FirstName", "firstName")]
    [QueryProperty("Initials", "initials")]
    [QueryProperty("UserColour", "userColour")]
    [QueryProperty("UserId", "userId")]


    public class UserChatViewModel : BaseViewModel
    {
        IDataStore<Message> MessageDataStore => DependencyService.Get<IDataStore<Message>>(); 

        public ObservableCollection<Message> Messages { get; }

        User CurrentUser = UserDataStore.CurrentUser;

        // Properties passed from ChatViewModel
        private string name;
        private string firstName;
        private string initials;
        private string userColour;
        private string userId;

        // Text entered by user, saved to database
        private string messageText;

        public Command SaveChat { get; }

        public Command LoadItemsCommand { get; }

        public UserChatViewModel()
        {
            SaveChat = new Command(OnSave);
            Messages = new ObservableCollection<Message>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            LoadItemsCommand.Execute(null);
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

        public string UserId
        {
            get => userId;
            set
            {
                SetProperty(ref userId, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(userId));
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
                var messages = await MessageDataStore.GetItemsAsync(true);

                if (messages.Count() == Messages.Count())
                {
                    return;
                } else
                {
                    Messages.Clear();
                    foreach (var message in messages)
                    {
                        if (message.To == firstName && message.From == CurrentUser.FirstName || message.To == CurrentUser.FirstName && message.From == firstName)
                        {
                            Messages.Add(message);
                        }
                    }
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
                Text = messageText,
                Timestamp = DateTime.Now.ToString("dd/MM/yyyy HH:mmtt"),
                To = firstName,
                From = UserDataStore.CurrentUser.FirstName
            };

            await MessageDataStore.AddItemAsync(newMessage);

            await ExecuteLoadItemsCommand();
        }

    }
}
