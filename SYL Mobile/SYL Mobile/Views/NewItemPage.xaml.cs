using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SYL_Mobile.Models;
using SYL_Mobile.ViewModels;

namespace SYL_Mobile.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Product product { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}