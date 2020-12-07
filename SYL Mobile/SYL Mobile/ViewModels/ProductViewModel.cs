using SYL_Mobile.Models;
using SYL_Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SYL_Mobile.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {

        public string Price { get; set; }

        public string sellerName { get; set; }

        public string Distance { get; set; }

        public Position position { get; set; }

        public Command PlaceOrderCommand { get; set; }

        public ProductViewModel(Product p, Position pos)
        {
            position = pos;
            Price = p.price + " €/kg";
            Distance = p.distance + " km";
            sellerName = p.sellerName;
            PlaceOrderCommand = new Command(async () => await App.Current.MainPage.Navigation.PushAsync(new OrderAddPage(p)));
            
        }





    }
}
