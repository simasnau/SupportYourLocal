using SYL_Mobile.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SYL_Mobile.Services
{
    public static class OrderService
    {
        public static async Task<IEnumerable<Order>> loadOrders()
        {
            HttpClient client = new HttpClient();
            string url = "https://syl.azurewebsites.net/order/4";
            string response = await client.GetStringAsync(url);
            var orderList = JsonSerializer.Deserialize<List<Order>>(response);
            return orderList;
        }

        public static async Task<int> getSellerId(String sellerName)
        {
            HttpClient client = new HttpClient();
            string url = "https://syl.azurewebsites.net/seller?name=" + sellerName;
            string response = await client.GetStringAsync(url);
            return int.Parse(response);
            
        }

        public static async Task<bool> AddOrderAsync(FormUrlEncodedContent order)
        {
            var url = "https://syl.azurewebsites.net/order/add";
            var client = new HttpClient();
            var response = await client.PostAsync(url, order);
            return await Task.FromResult(true);
        }

        public static async Task<IEnumerable<Order>> GetOrdersAsync(bool forceRefresh = false)
        {
            return await loadOrders();
        }

    }
}
