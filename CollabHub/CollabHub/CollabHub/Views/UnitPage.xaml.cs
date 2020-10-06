﻿using CollabHub.ViewModels;
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
    public partial class UnitPage : ContentPage
    {

        private UnitViewModel ViewModel { get; set; }
        
        public UnitPage()
        {
            ViewModel = new UnitViewModel();
            InitializeComponent();
            this.BindingContext = ViewModel;
        }
    }
}