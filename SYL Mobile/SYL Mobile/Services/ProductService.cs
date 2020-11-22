using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SYL_Mobile.Models;

namespace SYL_Mobile.Services
{
    public static class ProductService 
    {      
        public static async Task<IEnumerable<Product>> loadProducts()
        {
            HttpClient client = new HttpClient();
            string url = "https://syl.azurewebsites.net/product";
            string response = await client.GetStringAsync(url);
            var productList= JsonSerializer.Deserialize<List<Product>>(response);
            
            return productList;
        }

        public static async Task<bool> AddProductAsync(FormUrlEncodedContent product)
        {
            var url = "https://syl.azurewebsites.net/product/add";
            var client = new HttpClient();
            var response = await client.PostAsync(url, product);

            return await Task.FromResult(true);
        }

       
        public static async Task<IEnumerable<Product>> GetProductsAsync(bool forceRefresh = false)
        {
            return await loadProducts();
        }
    }
}