using System;
using System.Collections.Generic;
using System.IO.Compression;
using StoreApp.Library;
using StoreApp.Library.Printer;


namespace StoreApp.Library
{
    public class Store
    {
        // initialize default store number
        private static int StoreSeed = 101;

        //fields
        public int StoreID { get; set; }
        public string Name { get; set; }
        public string Stree { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }

        // each store has an inventory customer and order history
        private List<Product> inventory = new List<Product>();
        private List<Order> orderHistory = new List<Order>();

        public List<Product> Inventory => inventory;
        public List<Order> Order => orderHistory;

        //create print object
        private readonly IPrint print = new PrinterConsole();

        //default constructor 
        //ADD MORE INFO FOR STORE
        public Store (int zip)
        {
            StoreID = StoreSeed;
            StoreSeed++;
            Zip = zip;
        }
        // returns all the data in a string format
        public string getData()
        {
            return $"{StoreID} |  {Zip}";
        }

        // Add item to inventory to list
        public void AddInventory(Product item)
        {
            inventory.Add(item);
        }
        // Add customer to list

        // add order to order History
        public void AddOrder(Order transaction)
        {
            orderHistory.Add(transaction);
            print.PrintAddOrder(transaction);

        }
        // reference inventory
        public Product getInventory(int index)
        {
            return inventory[index];
        }
        public int getId()
        {
            return StoreID;
        }


        public void printInventory() => print.PrintGetInventory(inventory);
        public void printOrders() => print.PrintOrderHistory(orderHistory);

        public void Search(int ID, int quantity, string choice)
        {
            bool searchSuccess = false;
            foreach (var item in inventory)
            {
                if(item.getID() == ID)
                {
                    if (choice == "u")
                        item.updateQuantity(quantity);
                    else
                        item.setQuantity(quantity);
                    searchSuccess = true;
                }
            }
            if (searchSuccess)
                print.PrintAddedItemSuccessfull();
            else
                print.PrintAddedItemUnsucessfull();
        }

        // Delegaters


    }
}
