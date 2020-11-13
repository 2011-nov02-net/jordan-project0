using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Library.Printer
{
    class PrinterConsole : IPrint
    {
        public void PrintStores(List<Store> database)
        {
            foreach(var store in database)
            {
                Console.WriteLine(store.getData());
            }
        }
        public void PrintAddOrder(Order transaction)
        {
            Console.WriteLine("Order Added Your total is: " + transaction.Cost);
        }
        public void PrintAddInventory()
        {
            Console.WriteLine();
        }
        public void PrintGetInventory(List<Product> inventory)
        {
            foreach(var item in inventory )
            {
                Console.WriteLine(item.ToString());
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
                Console.WriteLine(order.ToString());

            }
        }
        public void PrintCustomersOrders(List<Order> orderHistory)
        {
            Console.WriteLine();
        }
        public void PrintAddedItemSuccessfull()
        {
            Console.WriteLine("Item Added/Set Successful");
        }
        public void PrintAddedItemUnsucessfull()
        {
            Console.WriteLine("Item Not added");
        }

    }
}
