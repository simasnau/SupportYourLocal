using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using SYL_Mobile.Models;
using SYL_Mobile.Views;
using System.Collections.Generic;
using Trust_Your_Locals;
using SYL_Mobile.Services;
using SYL.Mobile.Services;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using System.Threading;

namespace SYL_Mobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Product _selectedProduct;

        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products {
            get { return products; }
            set { SetProperty(ref products, value,"Products"); }
        }

        Dictionary<string, Position> adressCoordinates;

        public Command LoadItemsCommand { get;  }
        public Command AddItemCommand { get; }
        public Command<Product> ItemTapped { get; }
        private Product _selectedProd { get; set; }
        public Product SelectedProduct {  
            get { return _selectedProd; } 
            set { if (_selectedProd != value) 
                { _selectedProd = value; } } }

        public ItemsViewModel()
        {
            Title = "Products";
            Products = new ObservableCollection<Product>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            AddItemCommand = new Command(async () => await App.Current.MainPage.Navigation.PushAsync(new NewItemPage()));

            adressCoordinates = new Dictionary<string, Position>();

            var timer = new Timer((e) => UpdateDistance(), null, TimeSpan.Zero, TimeSpan.FromSeconds(5)); 

        }
        

        async void UpdateDistance()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));
            var location = await Geolocation.GetLocationAsync(request, new CancellationTokenSource().Token);
            var curPos = new Position(location.Latitude, location.Longitude);

            var productList = new ObservableCollection<Product>(Products);
           
            foreach(var product in productList)
            {
                var pos = adressCoordinates[product.adress];
                product.distance = Math.Round(Distance.BetweenPositions(pos, curPos).Kilometers, 2);
            }

            Products = productList;

        }



        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                var products = await ProductService.GetProductsAsync(true);
                var request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLocationAsync(request, new CancellationTokenSource().Token);
                var curPos = new Position(location.Latitude, location.Longitude);

                List<string> adressList = products.Select(x => x.adress).Distinct().ToList();
                foreach (var adress in adressList) adressCoordinates.Add(adress, await MapService.getCoordinates(adress));

                Products.Clear();

                foreach (var product in products) {
                    var pos = adressCoordinates[product.adress];
                    product.distance = Math.Round(Distance.BetweenPositions(pos, curPos).Kilometers,2);
                    Products.Add(product);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            
            IsBusy = true;
            SelectedItem = null;
        }

        public Product SelectedItem
        {
            
            get => _selectedProduct;
            set
            {
                SetProperty(ref _selectedProduct, value);
            }
        }

    }
}