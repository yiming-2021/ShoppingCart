using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Data.Model
{
    public class Orders
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal? Total { get; set; }
        public int CustomerID { get; set; }

        public Customers Customers { get; set; }
    }
}
