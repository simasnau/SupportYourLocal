using SYL.Mobile.Services;
using SYL_Mobile.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SYL.Mobile.ViewModels
{
	public class MapViewModel : ContentView
{
        private IEnumerable<Product> currentProducts;

        private List<Pin> Pins;

        private Xamarin.Forms.Maps.Map map;

        public MapViewModel(Xamarin.Forms.Maps.Map map, IEnumerable itemsSource)
        {
            Pins = new List<Pin>();

            this.map = map;


            currentProducts = (IEnumerable<Product>)itemsSource;

            ExecuteLoadPinsCommand();

        }

        async void ExecuteLoadPinsCommand()
        {
            List<string> adressList = currentProducts.Select(x => x.adress).Distinct().ToList();

            map.Pins.Clear();
            foreach (var adress in adressList)
            {
                map.Pins.Add(new Pin { 
                    Label= currentProducts.Where(x => x.adress == adress).Select(x => x.sellerName).First(),
                    Address=adress,
                    Type=PinType.Place,
                    Position=await MapService.getCoordinates(adress)

                });
            }

        }
    }
}