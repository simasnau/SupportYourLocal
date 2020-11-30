using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SYL_Mobile.Models;

using SYL_Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SYL_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderAddPage : ContentPage
    {
        Product sendSeller;
        // DateTime _triggerTime;
        public OrderAddPage(Product seller)
        {
            sendSeller = seller;
            // _timePicker.Time.ToString(), _entry.Text   reikia situ
            InitializeComponent();
            BindingContext = new AddOrderViewModel(seller);
            _label.Text += seller.name;
           // String taim = _timePicker.Time.ToString();
        }
        void OnTimePickerPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Time")
            {
                BindingContext = new AddOrderViewModel(sendSeller, _timePicker);

                //SetTriggerTime();
            }
        }

        private void _timePicker_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            BindingContext = new AddOrderViewModel(sendSeller, _timePicker);

        }


        //void SetTriggerTime()
        //{
        //    if (_switch.IsToggled)
        //    {
        //        _triggerTime = DateTime.Today + _timePicker.Time;
        //        if (_triggerTime < DateTime.Now)
        //        {
        //            _triggerTime += TimeSpan.FromDays(1);
        //        }
        //    }
        //}
        //    void OnSwitchToggled(object sender, ToggledEventArgs args)
        //    {
        //        SetTriggerTime();
        //    }
    }
}