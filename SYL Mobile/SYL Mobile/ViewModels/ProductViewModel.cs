﻿using SYL_Mobile.Models;
using SYL_Mobile.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SYL_Mobile.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {

        public string Price { get; set; }

        public string sellerName { get; set; }

        private string distance;
        public string Distance {
            get { return distance; }
            set { SetProperty(ref distance, value); }
        }

        public Position position { get; set; }

        public Command PlaceOrderCommand { get; set; }

        public ProductViewModel(Product p, Position pos)
        {
            position = pos;
            Price = p.price + " €/kg";
            Distance = p.distance + " km";
            sellerName = p.sellerName;
            PlaceOrderCommand = new Command(async () => await App.Current.MainPage.Navigation.PushAsync(new OrderAddPage(p)));

            var timer = new Timer((e) => UpdateDistance(), null, TimeSpan.Zero, TimeSpan.FromSeconds(5)); 

        }

        async void UpdateDistance()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLocationAsync(request, new CancellationTokenSource().Token);
                var curPos = new Position(location.Latitude, location.Longitude);
                Distance = Convert.ToString(Math.Round(Xamarin.Forms.Maps.Distance.BetweenPositions(position, curPos).Kilometers, 2)) + " km";
            }
            catch (PermissionException e)
            {
                Distance = "Unable to get distance.";
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }


            
        }







    }
}
