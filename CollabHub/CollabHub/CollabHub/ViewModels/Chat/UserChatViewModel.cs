using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CollabHub.ViewModels
{
    [QueryProperty("Name", "name")]

    class UserChatViewModel : BaseViewModel
    {
        string name;

        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(Name));
            }
        }

    }
}
