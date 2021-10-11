using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Data.Model;
using ShoppingCart.Data.Repository;

namespace ShoppingCart.Services
{
    public class CartServices
    {
        OrderDetailsRepository orderDetailsRepository;
        OrderRepository orderRepository;
        public CartServices()
        {
            orderRepository = new OrderRepository();
            orderDetailsRepository = new OrderDetailsRepository();
        }

        public void RecordOrders(decimal total)
        {
            Orders orders = new Orders();
            orders.OrderDate = DateTime.Now;
            Console.Write("Customer ID = ");
            orders.CustomerID = Convert.ToInt32(Console.ReadLine());
            orders.Total = total;
            orderRepository.Insert(orders);
            Console.WriteLine("Order has been recorded successfully");
        }

        public void RecordOrderDetails(Dictionary<(int,string),int> itemsInCart)
        {
            OrderDetails orderDetails = new OrderDetails();
            Orders orders = new Orders();
            int orderid = orderRepository.GetOrderId().ID;

            foreach (var item in itemsInCart)
            {
                orderDetails.OrderID = orderid;
                orderDetails.ProductID = item.Key.Item1;
                orderDetails.Quantity = item.Value;
                orderDetailsRepository.Insert(orderDetails);
            }

            Console.WriteLine("Order Details have been recorded successfully");
        }


    }
}
