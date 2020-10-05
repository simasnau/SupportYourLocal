using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trust_Your_Locals
{
    public class Product
    {
        public String name { get; set;}
        public int shopID { get; set; }
        public float price { get; set; }
        public int productTypeID { get; set; }

        Product (String name, int shopID, float price, int productTypeID)
        {
            this.name = name;
            this.shopID = shopID;
            this.price = price;
            this.productTypeID = productTypeID;
        }


    }
}
