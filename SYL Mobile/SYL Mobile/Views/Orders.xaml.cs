using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SYL_Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SYL_Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class Orders : ContentPage
{
        OrderViewModel _viewModel;

        public Orders()
        {
        InitializeComponent();
        BindingContext = _viewModel = new OrderViewModel();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
        //private void searchBarTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    string text = searchBar.Text.ToLower();
        //    var searchResult = _viewModel.Products.Where(c => (c.name.ToLower().Contains(text) || c.sellerName.ToLower().Contains(text)));
        //    OrderListView.ItemsSource = searchResult;
        //}

    }
}