using System;
using System.Collections.Generic;
using System.IO.Compression;
using StoreApp.Library;
using StoreApp.Library.Printer;
using System.Linq;


namespace StoreApp.Library
{
    public class Store
    {
        // initialize default store number
        private static int StoreSeed = 101;

        //fields
        public int StoreID { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        // each store has an inventory customer and order history
        private List<Product> inventory = new List<Product>();
        private List<Order> orderHistory = new List<Order>();

        // replace inventory with user value;
        public List<Product> Inventory
        {
            get
            {
                return inventory;
            }
            set
            {
                inventory = value;
            }
        }
        public List<Order> Order => orderHistory;

        //create print object
        private readonly IPrint print = new PrinterConsole();

        //default constructor 
        //ADD MORE INFO FOR STORE
        public Store (int storeid, string name, string state, string street, string city, string zip)
        { 
            StoreSeed = StoreID+1;
            StoreID = storeid;
            Name = name;
            State = state;
            Street = street;
            City = city;
            Zip = zip;
        }
        /// <summary>
        /// Constructor for when we only want the id of the store
        /// </summary>
        public Store(int storeid)
        {
            StoreID = storeid;
        }


        // Add item to inventory to list
        public void AddInventory(Product item)
        {
            inventory.Add(item);
        }

        // add order to order History
        public void AddOrder(Order transaction)
        {
            orderHistory.Add(transaction);
            print.PrintAddOrder(transaction);

        }
        // reference store by inventory index
        public Product getInventory(int index)
        {
            // use linq to find item.
            var item = inventory.FirstOrDefault(o => o.ProductID ==index);
            // if item does not exist return a product with an itemid of 0;
            if (item == null)
            {
                Console.WriteLine("Item Not Found");
                return new Product();
            }
            return item;
        }

        public void printInventory() => print.PrintGetInventory(inventory);
        public void printOrders() => print.PrintOrderHistory(orderHistory);

        /// <summary>
        /// Search Method that checks if an item exists within a store. Update quantity if it exists.
        /// If the search is successful print Success message otherwise print error message.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="quantity"></param>
        /// <param name="choice"></param>
        public void Search(int ID, int quantity, string choice)
        {
            bool searchSuccess = false;
            foreach (var item in inventory)
            {
                if(item.ProductID == ID)
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

        /// <summary>
        /// Have a check statement to see if this is a real store. A real store should at least have a name.
        /// </summary>
        /// <returns>True or False</returns>
        public bool isValid()
        {
            if(String.IsNullOrEmpty(Name)) {
                Console.WriteLine("Not a Valid Store");
                return false;
            }
            return true;
        }
        public bool hasInventory()
        {
            if (Inventory.Count==0)
            {
                Console.WriteLine("This Store has no Inventory");
                return false;
            }
            return true;
        }
        // returns all the data in a string format
        public override string ToString()
        {
            return $"ID: {StoreID} | {Name} | {State} | {City} | {Street} |  {Zip}";
        }

    }
}
