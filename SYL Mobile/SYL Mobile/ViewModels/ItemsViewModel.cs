﻿using System;
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

namespace SYL_Mobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Product _selectedProduct;

        public ObservableCollection<Product> Products { get; set; }

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

        }
        

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                var products = await ProductService.GetProductsAsync(true);
                Products.Clear();               
               foreach (var product in products) Products.Add(product);
                              
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