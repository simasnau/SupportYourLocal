using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using SYL_Mobile.Models;
using SYL_Mobile.Services;
using System.Text.Json;
using Trust_Your_Locals;
using Xamarin.Forms;
using System.Diagnostics;

namespace SYL_Mobile.ViewModels
{
    public class AddOrderViewModel : BaseViewModel
    {
      

        private string text;
        public static Product product;
        public String time;
        
        public String quantity;

        public List<string> ProductEnum { get; }

        public AddOrderViewModel(Product sell)
        {
            product = sell;

            ProductEnum = new List<string>(Enum.GetNames(typeof(ProductEnum)));

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        public AddOrderViewModel(Product sell, TimePicker timePicker)
        {
            time = timePicker.Time.ToString();
            product = sell;

            ProductEnum = new List<string>(Enum.GetNames(typeof(ProductEnum)));

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }


        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && product != null;
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }


        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            int sID = await ProductService.getSellerId(product.sellerName);
            var order = new FormUrlEncodedContent(new[]
            {                
                new KeyValuePair<string, string>("name", product.name),
                new KeyValuePair<string, string>("time", time.Substring(0, 5)),
                new KeyValuePair<string, string>("quantity", text),
                new KeyValuePair<string, string>("bID", 4.ToString()),   // user.getId
                new KeyValuePair<string, string>("sID", sID.ToString())
            });
            
            //Debug.WriteLine(product.name + " " + time.Substring(0, 5) + " " + text + " " + 4.ToString() + " " + sID.ToString());
            
            
            await ProductService.AddOrderAsync(order);

            await Shell.Current.GoToAsync("..");
        }

    }
}
