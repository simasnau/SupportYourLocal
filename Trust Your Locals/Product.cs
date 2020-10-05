using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trust_Your_Locals
{
    public class Product
    {
        String name;
        int shopID;
        float price;
        int productTypeID;

        Product (String name, int shopID, float price, int productTypeID)
        {
            this.name = name;
            this.shopID = shopID;
            this.price = price;
            this.productTypeID = productTypeID;
        }


    }
}
