
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
        /// <summary>
        /// Main menu that starts with options to print search create
        /// </summary>
        /// <param name="DB"></param>
        public static void mainMenu(StoreRepository DB) {
            SqlDb = DB;
            string choice = "";
            while (choice != "q"){
                Console.WriteLine("at the main Menu type 'q' to quit.");
                Console.WriteLine("Need to (p)rint, (s)earch for customers, (a)dd a customer (m)ake an order");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    // Bring up print menu
                    case "p":
                        printMenu();
                        break;
                    // Bring up Customer Search
                    case "s":
                        customerSearch();
                        break;
                    // Create a new Customer
                    case "a":
                        CreateCustomer();
                        break;
                    // Create a new Order
                    case "m":
                        makeOrder();
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Menu that holds all the case statements for what you would like to print
        /// </summary>
        public static void printMenu()
        {
            Console.WriteLine("At the Print Menu");
            Console.WriteLine("What do you want to print: (s)tores (c)ustomers (i)nventory (o)rders?");

            // choose a case between any of these
            switch (Console.ReadLine().ToLower())
            {
                // print all stores
                case "s":
                    Console.WriteLine("-- Printing all Stores");
                    uiPrintAllStores();
                    break;
                // print all customers
                case "c":
                    Console.WriteLine("--- Printing All Customers ---");
                    uiPrintAllCustomers();
                    break;
                // print all inventory of a store
                case "i":
                    Console.WriteLine();
                    uiPrintStoreInventory();
                    break;
                // go to print orders menu
                case "o":
                    Console.WriteLine();
                    printOrdersMenu();
                    break;
                default:
                    Console.WriteLine("Not a valid entry going back");
                    break;

            }
        }
        /// <summary>
        /// Contains printOrderMenu which can call all the print functions such as:
        /// Store Orders, Customer Orders, and Individual Orders
        /// </summary>
        public static void printOrdersMenu()
        {
            Console.WriteLine("At the Printing Order Menu: ");
            Console.WriteLine("What do you want to print: (s)tore Orders (c)ustomer orders (o)rder Details?");

            switch (Console.ReadLine().ToLower())
            {
                // print store orders
                case "s":
                    uiPrintStoreOrders();
                    break;
                // print customer orders
                case "c":
                    uiPrintCustomerOrders();
                    break;
                // print an individual order
                case "o":
                    uiGetOrder();
                    break;
                // go back to print menu after
                default:
                    Console.WriteLine("Going back to print menu");
                    printMenu();
                    break;
            }

        }
        /// <summary>
        /// Customer Search grabs all the customers and uses the built in method to find customers.
        /// </summary>
        public static void customerSearch()
        {
            List<Customer> customers = SqlDb.GetAllCustomers();
            DataBase db = new DataBase(customers);
            Console.WriteLine("What do you want to search by: (f)irst name, (l)ast name, (i)d:  ");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                // search by first name
                case "f":
                    Console.WriteLine("enter a first name");
                    Console.WriteLine(db.customerSearchFirstName(Console.ReadLine()));
                    break;
                // search by last name
                case "l":
                    Console.WriteLine("Enter a Last Name");
                    Console.WriteLine(db.customerSearchLastName(Console.ReadLine()));
                    break;
                // search by id
                case "i":
                    Console.WriteLine("Enter an ID");
                    Customer temp = db.customerSearchID(Console.ReadLine());
                    Console.WriteLine(temp.ToString());
                    break;
                // go back to main menut
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
            Order order = db.getFirstOrder();
            Console.WriteLine(order.newOrderString(order.TransactionNumber));
        }
        public static void CreateCustomer()
        {
            Console.WriteLine("Enter Customer's First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Customer's Last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Customer's Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Customer's Phone: ");
            string phone = Console.ReadLine();

            var customer = new Customer(firstName, lastName, email, phone);

            if (customer.isValid())
            {
                SqlDb.AddCustomer(customer);
                Console.WriteLine("Customer Added" );
            }
            else
            {
                Console.WriteLine("Customer does not meet one of the guidelines.");
            }
        }
        public static void makeOrder()
        {
            // get all of the customers
            List<Customer> customers = SqlDb.GetAllCustomers();
            Library.DataBase db = new Library.DataBase(customers);

            // Print a list of the customers
            db.printCustomers();
            Console.WriteLine("Enter a Customer ID");
            string customerId = Console.ReadLine();

            // select your customer
            Customer customer = SearchCustomers.customerSearchID(customers, customerId);

            // don'd continue unless the person actually put in a correct customer id.
            if (customer.isValid())
            {
                // get the store information
                uiPrintAllStores();
                Console.WriteLine("Choose a Store: ");
                int storeId = Int32.Parse(Console.ReadLine());
                Store store = SqlDb.GetInventory(storeId);
                if (store.hasInventory())
                {
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
                        if (choice != "q")
                        {
                            int choiceCheck = 0;
                            int.TryParse(choice, out choiceCheck);

                            // using the only store in the database grab the product from the inventory
                            var item = db[0].getInventory(choiceCheck);

                            Console.WriteLine("Choose a quantity: ");

                            //give user a chance to escape one more time
                            string quantity = Console.ReadLine();
                            if (quantity != "q")
                            {

                                int quantityCheck = 0;
                                int.TryParse(quantity, out quantityCheck);

                                newOrder.addItem(item, quantityCheck);
                                Console.WriteLine("Your Total So Far is " + newOrder.Cost);
                            }
                        }

                        db.Stores[0].AddOrder(newOrder);

                    }
                    // if we have items in our order submit to database
                    if (newOrder.hasItems())
                    {
                        int TransactionNumber = SqlDb.AddCustomerOrder(db);
                        Console.WriteLine(newOrder.newOrderString(TransactionNumber));
                    }

                }
            }
        }

    }
}