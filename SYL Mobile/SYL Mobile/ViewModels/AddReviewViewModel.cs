using System;
using System.Collections.Generic;
using System.Text;
using SYL_Mobile.Models;
using SYL_Mobile.Services;
using Xamarin.Forms;
using System.Net.Http;
using System.Diagnostics;

namespace SYL_Mobile.ViewModels
{
    class AddReviewViewModel : BaseViewModel
{
        public Product product;
        public String rating;
        public String comment;
        public TimeSpan Time { get; set; }

        public AddReviewViewModel(Product product, String rating, String comment)
        {
            this.product = product;
            this.rating = rating;
            this.comment = comment;
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }


        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(comment)
                && rating != "0";
        }

        public string Text
        {
            get => comment;
            set => SetProperty(ref comment, value);
        }


        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }

        private async void OnSave()
        {
            var review = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", "Lukas"),
                new KeyValuePair<string, string>("rating", rating),
                new KeyValuePair<string, string>("text", comment),   
            });
            Debug.WriteLine("username" + " Lukas"+" rating "+ rating +" text "+ comment +" sellerName "+ product.sellerName);
            await ReviewService.AddReviewAsync(review, product.sellerName);

            await App.Current.MainPage.Navigation.PopToRootAsync();
        }

    }
}
