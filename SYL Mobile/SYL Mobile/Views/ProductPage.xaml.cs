using SYL_Mobile.Models;
using SYL_Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace SYL_Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        ProductViewModel context;

        public ProductPage(Product product, Position position)
        {
            InitializeComponent();
            BindingContext = context = new ProductViewModel(product, position);
            image.Source = $"https://syl.azurewebsites.net/images/{product.name.ToLower()}";
        }
    }
}