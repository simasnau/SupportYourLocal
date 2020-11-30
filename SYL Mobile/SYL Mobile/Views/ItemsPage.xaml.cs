 using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SYL_Mobile.ViewModels;
using SYL.Mobile.ViewModels;

namespace SYL_Mobile.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;
        public String returnedProduct="products: "; 
        
        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ItemsViewModel();
        }
       
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void searchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            string text = searchBar.Text.ToLower();
            var searchResult=_viewModel.Products.Where(c => (c.name.ToLower().Contains(text) || c.sellerName.ToLower().Contains(text)));
            ItemsListView.ItemsSource = searchResult;
        }

        private async void ShowMapClicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new MapPage(ItemsListView.ItemsSource));
        }
    }
}