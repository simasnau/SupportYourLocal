using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using SYL_Mobile.Models;
using SYL_Mobile.Views;
using System.Collections.Generic;
using SYL_Mobile.Services;
using SYL.Mobile.Services;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using System.Threading;

namespace SYL_Mobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products {
            get { return products; }
            set { SetProperty(ref products, value,"Products"); }
        }

        Dictionary<string, Position> adressCoordinates;

        public Command LoadItemsCommand { get;  }
        public Command AddItemCommand { get; }
        public Command ItemTapped { get; }

        private Product _selectedProd;
        public Product SelectedProduct {  
            get { return _selectedProd; } 
            set { if (_selectedProd != value) 
                    {
                    SetProperty(ref _selectedProd, value);
                    } 
            } 
        }

        public ItemsViewModel()
        {
            Title = "Products";
            Products = new ObservableCollection<Product>();

            adressCoordinates = new Dictionary<string, Position>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            AddItemCommand = new Command(async () => await App.Current.MainPage.Navigation.PushAsync(new NewItemPage()));

            ItemTapped = new Command(async () => {
                if (SelectedProduct == null) return;
                else
                {
                    await App.Current.MainPage.Navigation.PushAsync(new ProductPage((Product)SelectedProduct, adressCoordinates[SelectedProduct.adress]));
                    SelectedProduct = null;
                }                
            });

            

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
        }


    }
}