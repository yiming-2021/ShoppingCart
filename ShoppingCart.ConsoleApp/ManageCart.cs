using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Data.Model;
using ShoppingCart.Data.Repository;
using ShoppingCart.Services;

namespace ShoppingCart.ConsoleApp
{
    class ManageCart
    {
        Dictionary<(int,string), int> itemsInCart = new Dictionary<(int, string), int>();
        ProductsRepository productsRepository = new ProductsRepository();

        CartServices cartServices;
        public ManageCart()
        {
            cartServices = new CartServices();
        }

        void PrintAllProducts()
        {
            var collection = productsRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{ item.ID} \t {item.PName } \t {item.UnitPrice }");
            }
        }



        public void AddItem()
        {
            Console.Write("Enter Product ID = ");
            int pId = Convert.ToInt32(Console.ReadLine());

            string pName = productsRepository.GetById(pId).PName;

            Console.Write("Enter Quantity = ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            if (itemsInCart.ContainsKey((pId,pName))){
                itemsInCart[(pId, pName)] += quantity;
            }
            else
            {
                itemsInCart.Add((pId, pName), quantity);
            }

            Console.WriteLine("Item(s) added.");
        }


        public void ViewAll()
        {
            foreach (var pair in itemsInCart)
            {
                Console.WriteLine($"Product Name: {pair.Key.Item2} , Quantity={pair.Value}");
            }
        }

        public void RemoveItem()
        {
            Console.Write("Enter Product ID = ");
            int pId = Convert.ToInt32(Console.ReadLine());

          
            string pName = productsRepository.GetById(pId).PName;

            Console.Write("Enter Quantity to remove = ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            if (itemsInCart.ContainsKey((pId, pName)))
            {
                if (itemsInCart[(pId, pName)] - quantity >= 0)
                {
                    itemsInCart[(pId, pName)] -= quantity;
                    Console.WriteLine("Item(s) removed!");
                }
                else
                {
                    Console.WriteLine("The quantity to remove cannot exceed the current quantity.");
                }
                
            }
            else
            {
                Console.WriteLine("The item is not in the cart.");
            }

            
        }


        public void Checkout()
        {
            decimal total = 0;

            foreach (var item in itemsInCart)
            {
                if (item.Key.Item1 == 1)
                {
                    total += productsRepository.GetById(item.Key.Item1).UnitPrice * (item.Value/2+ item.Value%2);
                }
                if (item.Key.Item1 == 2)
                {
                    total += productsRepository.GetById(item.Key.Item1).UnitPrice * (item.Value / 3 *2 + item.Value % 3);
                }
            }

            Console.WriteLine("Total Price is: $" + total);
            Console.WriteLine("Thank you for shopping!");

            cartServices.RecordOrders(total);
            cartServices.RecordOrderDetails(itemsInCart);
        }


        public void Run()
        {
            int choice = 0;

            do
            {
                Console.Clear();
                Menu m = new Menu();
                choice = m.Print(typeof(Operations));
                switch (choice)
                {
                    case (int)Operations.AddItem:
                        PrintAllProducts();
                        AddItem();
                        break;
                    case (int)Operations.ViewAll:
                        ViewAll();
                        break;
                    case (int)Operations.RemoveItem:
                        PrintAllProducts();
                        RemoveItem();
                        break;
                    case (int)Operations.Checkout:
                        Checkout();
                        break;
                    case (int)Operations.Exit:
                        Console.WriteLine("Maybe Next time!");
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
                Console.WriteLine("Press Enter to continue.....");
                Console.ReadLine();
            } while (choice != (int)Operations.Exit && choice != (int)Operations.Checkout);
        }

    }
}
