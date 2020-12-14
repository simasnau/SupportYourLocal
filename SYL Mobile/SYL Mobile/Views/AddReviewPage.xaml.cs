using System;
using System.Collections.Generic;
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
public partial class AddReviewPage : ContentPage
{
        //AddReviewPage a = new AddReviewPage();
        //Syncfusion.SfRating.XForms.SfRating rate = a.rating;
        Product product;
    public AddReviewPage()
        {
            InitializeComponent();
            
        }
    public AddReviewPage(Product product)

    {
            
            InitializeComponent();
            this.product = product;
            BindingContext = new AddReviewViewModel(product, rating.Value.ToString(), _entry.Text);
            _label.Text += product.sellerName;
        
    }

        private void rating_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            BindingContext = new AddReviewViewModel(product, rating.Value.ToString(), _entry.Text);
        }
    }
}