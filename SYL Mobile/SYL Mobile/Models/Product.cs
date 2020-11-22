﻿using System;

namespace SYL_Mobile.Models
{
    public class Product
    {
        public string Id = Guid.NewGuid().ToString("N");
        public string name { get; set; }
        public string adress { get; set; }
        public double price { get; set; }
        public string sellerName { get; set; }
    }
}