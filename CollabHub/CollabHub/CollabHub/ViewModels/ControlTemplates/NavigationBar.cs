
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CollabHub.ViewModels.ControlTemplates
{
    class NavigationBar : ContentView
    {
        public static readonly BindableProperty PageNameProperty = BindableProperty.Create(nameof(PageName), typeof(string), typeof(NavigationBar), string.Empty);

        public string PageName
        {
            get => (string)GetValue(PageNameProperty);
            set => SetValue(PageNameProperty, value);
        }
    }
}
