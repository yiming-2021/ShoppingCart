using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Data.Model
{
    public class OrderDetails
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int? Quantity { get; set; }

        public Products Products { get; set; }
        public Orders Orders { get; set; }
    }
}
