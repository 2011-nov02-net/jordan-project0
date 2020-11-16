
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using StoreApp.Library;

namespace StoreApp.AppConsole
{
    class SqlConsoleUi
    {
        static StoreRepository SqlDb;
        public static void mainMenu(StoreRepository DB) {
            SqlDb = DB;
            Console.WriteLine("at the main Menu type 'q' to quit.");
            Console.WriteLine("Need to (p)rint, (s)earch for customers, (a)dd a customer");
            switch (Console.ReadLine().ToLower()) {
                // Case Print
                case "p":
                    printMenu();
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
        public static void uiPrintStoreInventory()
        {
            // call the sql server and get all the stores first to choose an id
            uiPrintAllStores();
            Console.WriteLine("Choose a Store: ");

            Store store = SqlDb.GetInventory(Int32.Parse(Console.ReadLine()));
            store.printInventory();
        
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

    }
}