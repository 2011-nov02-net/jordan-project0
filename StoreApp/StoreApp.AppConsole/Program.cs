using StoreApp.Library;
using System;
using System.Collections.Generic;

namespace StoreApp.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Store Walmart = new Store(60042);
            Walmart.AddInventory(new Product("orange", 3 , 21.12));
            Walmart.AddInventory(new Product("bannanna", 123, .68));
            Walmart.AddInventory(new Product("tomatoe", 3, 3.00));
            Walmart.AddInventory(new Product("Milk", 12, 123));
            Walmart.AddInventory(new Product("Apple", 3, 21.12));
            Walmart.AddInventory(new Product("Bread", 34, 21.12));

            Walmart.AddCustomer(new Customer("Jordan", "Garcia", "jj@gmail.com", "847-543-8389"));
            Walmart.AddCustomer(new Customer("Eduardo", "Garcia", "jj@gmail.com", "847-543-8389"));
            Walmart.AddCustomer(new Customer("Nadia", "Bella", "jj@gmail.com", "847-543-8389"));



            // making order
            Order newOrder = new Order(Walmart.getId(), "Jordan", "Garcia");
            newOrder.addItem(Walmart.getInventory(0, 2));
            
            // addOrder
            Walmart.AddOrder(newOrder);


            var UI = new UserIntrerface();

            string userInput = Console.ReadLine();
            Console.WriteLine("at the main Menu type 'h' for help or 'q' to quit.");

            while (userInput != "q")
            {
                UI.selectScreen(Walmart, userInput);
                userInput = Console.ReadLine();
            }

        }
    }
}