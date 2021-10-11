using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.ConsoleApp
{
    class Dashboard
    {
        public void ShowDashboard()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor. DarkBlue;
            Console.Clear();
            Console.Title = "Shopping Cart";

            Console.WriteLine("Welcome to the online grocery!");
            
            ManageCart mc = new ManageCart();
            if (mc != null)
            {
                mc.Run();
            }

        }
    }
}
