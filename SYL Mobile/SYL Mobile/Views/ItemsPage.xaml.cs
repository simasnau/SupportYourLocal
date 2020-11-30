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
            //ItemsListView.SelectionChanged += OnCollectionViewSelectionChanged;
            
        }
       
     
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
//        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
//        {
//            string previous = (e.PreviousSelection.FirstOrDefault() as Models.Product)?.name;
//            var current = e.CurrentSelection;
//            string msg = String.Empty;
//            msg = "Selected Products:\n";
//            for (int i=0; i < current.Count; i++)
//            {
//                var product = current[i] as Models.Product;
//                msg += $"{product.name } ({product.Id})";
//                returnedProduct += $"{product.name}";

//            }
//            //DisplayAlert("Demo", msg, "Ok");
            
//}

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