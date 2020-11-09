using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Library.Printer
{
    class PrinterConsole : IPrint
    {
        public void PrintStores(DataBase db)
        {

        }
        public void PrintAddOrder(Order transaction)
        {
            Console.WriteLine("Order Added Your total is: " + transaction.GetCost());
        }
        public void PrintAddInventory()
        {
            Console.WriteLine();
        }
        public void PrintGetInventory(List<Product> inventory)
        {
            foreach(var item in inventory )
            {
                Console.WriteLine(item.getProductInfo());
            }
        }
        public void PrintCustomers(List<Customer> customers)
        {
            foreach(var customer in customers)
            {
                Console.WriteLine(customer.getCustomer());
            }
        }
        public void PrintOrderHistory(List<Order> orderHistory)
        {
            foreach(var order in orderHistory)
            {
                Console.WriteLine(order.getData());

            }
        }
        public void PrintCustomersOrders(List<Order> orderHistory)
        {
            Console.WriteLine();
        }
        public static void PrintAddedItemSuccessfull()
        {
            Console.WriteLine("Item Added Successful");
        }
        public static void PrintAddedItemUnsucessfull()
        {
            Console.WriteLine("Item Not added");
        }

    }
}
