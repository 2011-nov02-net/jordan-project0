using System;
using System.Collections.Generic;
using System.IO.Compression;
using StoreApp.Library;
using StoreApp.Library.Printer;


namespace StoreApp.Library
{
    public class Store
    {
        private static int StoreSeed = 3219032;

        private int StoreID { get; set; }
        private int Zip { get; set; }
        private List<Product> inventory = new List<Product>();
        private List<Customer> customers = new List<Customer>();
        private List<Order> orderHistory = new List<Order>();

        private readonly PrinterConsole print = new PrinterConsole();

        public Store (int zip)
        {
            StoreID = StoreSeed;
            StoreSeed++;
            Zip = zip;
        }

        public void AddInventory(Product item)
        {
            inventory.Add(item);
        }
        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }
        public void AddOrder(Order transaction)
        {
            orderHistory.Add(transaction);
            print.PrintAddOrder(transaction);

        }
        public Product getInventory(int index, int quanity)
        {
            return inventory[index];
        }
        public int getId()
        {
            return StoreID;
        }
        public void printCustomers()
        {
            print.PrintCustomers(customers);
        }
        public void printInventory()
        {
            print.PrintGetInventory(inventory);
        }
        public void printOrders()
        {
            print.PrintOrderHistory(orderHistory);
        }
    }
}
