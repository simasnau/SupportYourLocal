﻿using SYL_Mobile.Models;
using SYL_Mobile.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;
using SYL_Mobile.Services;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;

namespace SYL_Mobile.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {

        public string Price { get; set; }

        public string sellerName { get; set; }

        public double Avg { get; set; } = 3.5;

        private string distance;
        public string Distance {
            get { return distance; }
            set { SetProperty(ref distance, value); }
        }

        public string url;
        public Position position { get; set; }

        public Command PlaceOrderCommand { get; set; }

        public Command CheckReviewCommand { get; set; }

        public Command PlaceReviewCommand { get; set; }

        public Command ShowAvgRating { get; set; }

        public ProductViewModel(Product p, Position pos)
        {
            position = pos;
            Price = p.price + " €/kg";
            Distance = p.distance + " km";
            sellerName = p.sellerName;
            url = p.sellerName;
            GetAvgReview();

            ShowAvgRating = new Command(async () => await ExecuteLoadAvgReviewCommand());
            PlaceOrderCommand = new Command(async () => await App.Current.MainPage.Navigation.PushAsync(new OrderAddPage(p)));
            PlaceReviewCommand = new Command(async () => await App.Current.MainPage.Navigation.PushAsync(new AddReviewPage (p)));
            CheckReviewCommand = new Command(async () => await App.Current.MainPage.Navigation.PushAsync(new Reviews(p)));

            var timer = new Timer((e) => UpdateDistance(), null, TimeSpan.Zero, TimeSpan.FromSeconds(5)); 
            Debug.WriteLine("avgas = " + Avg);
        }
        public async void GetAvgReview( )
        {
           
            Avg = await ReviewService.loadAvgReview(url);
        }

        async Task<double> GetAvg()
        {
            
            //Avg = await ReviewService.loadAvgReview(url);
            return await ReviewService.loadAvgReview(url);
        }
        async Task ExecuteLoadAvgReviewCommand()
        {
            IsBusy = true;
            try
            {
                Avg = await ReviewService.loadAvgReview(url);
                

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
