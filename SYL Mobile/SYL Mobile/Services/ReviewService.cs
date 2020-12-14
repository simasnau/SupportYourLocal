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
    class ReviewService
{
        public static async Task<IEnumerable<Review>> loadReviews(string adress)
        {
            HttpClient client = new HttpClient();
            string url = "https://syl.azurewebsites.net/ratings/" + adress;
            string response = await client.GetStringAsync(url);
            var reviewList = JsonSerializer.Deserialize<List<Review>>(response);
            return reviewList;
        }

        //public static async Task<int> getSellerId(String sellerName)
        //{
        //    HttpClient client = new HttpClient();
        //    string url = "https://syl.azurewebsites.net/seller?name=" + sellerName;
        //    string response = await client.GetStringAsync(url);
        //    return int.Parse(response);
        //}

        public static async Task<bool> AddReviewAsync(FormUrlEncodedContent review, String sellerName)
        {
            var url = "https://syl.azurewebsites.net/ratings/" + sellerName + "/add";
            var client = new HttpClient();
            var response = await client.PostAsync(url, review);
            Debug.WriteLine("responsas" + response);
            
            Debug.WriteLine("urlas" + url);
            return await Task.FromResult(true);
        }

        public static async Task<IEnumerable<Review>> GetReviewsAsync(string url, bool forceRefresh = false )
        {
            return await loadReviews(url);
        }
    }
}
