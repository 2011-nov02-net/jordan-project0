
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using StoreApp.Library;
using StoreApp.Library.Location.Search;

namespace StoreApp.AppConsole
{
    class SqlConsoleUi
    {
        static StoreRepository SqlDb;
        public static void mainMenu(StoreRepository DB) {
            SqlDb = DB;
            Console.WriteLine("at the main Menu type 'q' to quit.");
            Console.WriteLine("Need to (p)rint, (s)earch for customers, (a)dd a customer (m)ake an order");
            switch (Console.ReadLine().ToLower()) {
                // Case Print
                case "p":
                    printMenu();
                    break;
                case "s":
                    customerSearch();
                    break;
                case "m":
                    makeOrder();
                    break;
                default:
                    break;

            }
        }
        public static void printMenu()
        {
            Console.WriteLine("At the Print Menu");
            Console.WriteLine("What do you want to print: (s)tores (c)ustomers (i)nventory (o)rders?");

            switch (Console.ReadLine().ToLower())
            {
                case "s":
                    Console.WriteLine("-- Printing all Stores");
                    uiPrintAllStores();
                    break;
                case "c":
                    Console.WriteLine("--- Printing All Customers ---");
                    uiPrintAllCustomers();
                    break;
                case "i":
                    Console.WriteLine();
                    uiPrintStoreInventory();
                    break;
                case "o":
                    Console.WriteLine();
                    printOrdersMenu();
                    break;
                default:
                    Console.WriteLine("Not a valid entry going back");
                    break;

            }
        }
        public static void printOrdersMenu()
        {
            Console.WriteLine("At the Printing Order Menu: ");
            Console.WriteLine("What do you want to print: (s)tore Orders (c)ustomer orders (o)rder Details?");

            switch (Console.ReadLine().ToLower())
            {
                case "s":
                    uiPrintStoreOrders();
                    break;
                case "c":
                    uiPrintCustomerOrders();
                    break;
                case "o":
                    uiGetOrder();
                    break;
                default:
                    Console.WriteLine("Going back to print menu");
                    printMenu();
                    break;
            }

        }
        public static void customerSearch()
        {
            List<Customer> customers = SqlDb.GetAllCustomers();
            DataBase db = new DataBase(customers);
            Console.WriteLine("What do you want to search by: (f)irst name, (l)ast name, (i)d:  ");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "f":
                    Console.WriteLine("enter a first name");
                    Console.WriteLine(db.customerSearchFirstName(Console.ReadLine()));
                    break;
                case "l":
                    Console.WriteLine("Enter a Last Name");
                    Console.WriteLine(db.customerSearchLastName(Console.ReadLine()));
                    break;
                case "i":
                    Console.WriteLine("Enter an ID");
                    Console.WriteLine(db.customerSearchID(Console.ReadLine()));
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

        }
        /// <summary>
        /// Function that calls the store repository and prints all the stores
        /// </summary>
        public static void uiPrintAllStores()
        {
            // call the sql server and get all stores
            List<Store> stores = SqlDb.GetAllStores();
            // set database to new stores and print using database method PrintStores
            DataBase db = new DataBase(stores);
            db.PrintStores();

        }
        /// <summary>
        /// Function that allows the user to print all the customers
        /// </summary>
        public static void uiPrintAllCustomers()
        {
            // call the sql server and get all the stores
            List<Customer> customers = SqlDb.GetAllCustomers();
            DataBase db = new DataBase(customers);
            db.printCustomers();
        }
        // <summary>
        // Function that allows the user to print all the Inventory of a specific store
        // </summarr>
        public static Store uiPrintStoreInventory()
        {
            // call the sql server and get all the stores first to choose an id
            uiPrintAllStores();
            Console.WriteLine("Choose a Store: ");

            Store store = SqlDb.GetInventory(Int32.Parse(Console.ReadLine()));
            store.printInventory();
            return store;
        
        }
        public static void uiPrintStoreOrders()
        {
            uiPrintAllStores();
            //            
            Console.WriteLine("Choose a Store: ");
            Store store = SqlDb.GetOrderHistoryOfStore(Int32.Parse(Console.ReadLine()));
            store.printOrders();

        }
        public static void uiPrintCustomerOrders()
        {
            uiPrintAllCustomers();
            Console.WriteLine("Choose a Customer: ");
            DataBase customer = SqlDb.GetOrderHistoryOfCustomer(Int32.Parse(Console.ReadLine()));
            customer.PrintOrders();
        }
        public static void uiGetOrder()
        {
            Console.WriteLine("Enter a Transaction Number: ");
            DataBase db = SqlDb.GetOrder(Int32.Parse(Console.ReadLine()));
            db.PrintOrders();
        }
        public static void UIaddCustomer(DataBase db)
        {
            Console.WriteLine("Enter Customer's First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Customer's Last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Customer's Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Customer's Phone: ");
            string phone = Console.ReadLine();
            db.AddCustomer(new Customer(firstName, lastName, email, phone));
        }
        public static void makeOrder()
        {
            Library.DataBase db = new Library.DataBase();

            List<Customer> customers = SqlDb.GetAllCustomers();
            Console.WriteLine("Enter a Customer ID");
            int customerId = Int32.Parse(Console.ReadLine());

            Customer customer = SearchCustomers.customerSearchID(customers, customerId);

            // get the store information
            Console.WriteLine("Choose a Store: " );
            int storeId = Int32.Parse(Console.ReadLine());
            Store store = SqlDb.GetInventory(storeId);
            // add store to our database
            db.AddStore(store);

            // making order
            Order newOrder = new Order(storeId, customer.CustomerId);
            store.printInventory();

            Console.WriteLine("Starting order press (q) to quit");
            string choice = "";
            while (choice.ToLower() != "q")
            {
                Console.WriteLine("Choose a Product");
                choice = Console.ReadLine();
                if (choice !="q")
                {
                    // using the only store in the database grab the product from the inventory
                    var item = db[0].getInventory(Int32.Parse(choice));

                    Console.WriteLine("Choose a quantity: ");

                    //give user a chance to escape one more time
                    string quantity = Console.ReadLine();
                    if (quantity != "q")
                    {
                        int quantityCheck = 0;
                        bool result = int.TryParse(quantity, out quantityCheck);

                        newOrder.addItem(item, quantityCheck);
                        Console.WriteLine("Your Total So Far is " + newOrder.Cost);

                    }

                }

            }
            Console.WriteLine(newOrder.ToString()); 



        }

    }
}