using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            //Debug.WriteLine("responsanas: lo" + response);
            return productList;
        }
        public static async Task<IEnumerable<Product>> loadOrders()
        {
            HttpClient client = new HttpClient();
            string url = "https://syl.azurewebsites.net/order/4";
            string response = await client.GetStringAsync(url);
            var orderList = JsonSerializer.Deserialize<List<Product>>(response);
            //Debug.WriteLine("responsanas: lo" + response);
            return orderList;
        }
        public static async Task<int> getSellerId(String sellerName)
        {
            HttpClient client = new HttpClient();
            string url = "https://syl.azurewebsites.net/seller?name=" + sellerName;
            string response = await client.GetStringAsync(url);
            //var productList = JsonSerializer.Deserialize<List<Product>>(response);
            //Debug.WriteLine("responsas: " + response);
            return int.Parse(response);
        }

        public static async Task<bool> AddProductAsync(FormUrlEncodedContent product)
        {
            var url = "https://syl.azurewebsites.net/product/add";
            var client = new HttpClient();
            var response = await client.PostAsync(url, product);

            return await Task.FromResult(true);
        }

        public static async Task<bool> AddOrderAsync(FormUrlEncodedContent order)
        {
            var url = "https://syl.azurewebsites.net/order/addOrder";
            var client = new HttpClient();
            var response = await client.PostAsync(url, order);
            //Debug.WriteLine("responsas: " + response);
            return await Task.FromResult(true);
        }

        public static async Task<IEnumerable<Product>> GetProductsAsync(bool forceRefresh = false)
        {
            return await loadProducts();
        }
        public static async Task<IEnumerable<Product>> GetOrdersAsync(bool forceRefresh = false)
        {
            return await loadOrders();
        }
        //public static async Task<int> GetSellerAsync(String name, bool forceRefresh = false)
        //{
        //    return await getSellerId(name);
        //}
    }
}