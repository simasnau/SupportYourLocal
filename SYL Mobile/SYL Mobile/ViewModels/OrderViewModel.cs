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

namespace SYL_Mobile.ViewModels
{
    class OrderViewModel : BaseViewModel
{
        private Order _selectedOrder;

        public ObservableCollection<Order> Orders { get; set; }

        public List<string> ProductEnum { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command OrderItemCommand { get; }
        public Command<Product> ItemTapped { get; }
        private Product _selectedProd { get; set; }
        public Product SelectedProduct
        {
            get { return _selectedProd; }
            set
            {
                if (_selectedProd != value)
                { _selectedProd = value; }
            }
        }

        public OrderViewModel()
        {


            Title = "Browse";
            Orders = new ObservableCollection<Order>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //AddItemCommand = new Command(OnAddItem);
            // if (ItemsPage.SelectedItem != null)

            //OrderItemCommand = new Command(OrderItem);
           // ProductEnum = new List<string>(Enum.GetNames(typeof(ProductEnum)));
        }


        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                var orders = await ProductService.GetOrdersAsync(true);
                Orders.Clear();
                foreach (var order in orders) Orders.Add(order);

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

        public Order SelectedItem
        {

            get => _selectedOrder;
            set
            {
                SetProperty(ref _selectedOrder, value);
            }
        }

        
        

    
}
}
