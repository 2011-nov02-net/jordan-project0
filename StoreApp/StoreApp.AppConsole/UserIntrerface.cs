using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using StoreApp.Library;
using StoreApp.Library.Printer;
using StoreApp.Library.Location.Search;

namespace StoreApp.AppConsole
{
    public class UserIntrerface
    {
       public static void selectScreen(DataBase db, string choice) {
            string choice2;
            switch (choice)
            {
                case "p":
                    Console.WriteLine("Entering Print Menu");
                    Console.WriteLine("Want to print (i)nventory, (c)ustomers, (o)rders");
                    choice2 = Console.ReadLine();
                    switch (choice2) {
                        case "i":
                            printInventory(db);
                            break;
                        case "c":
                            db.printCustomers();
                            break;
                        case "o":
                            printOrderHistory(db);
                            break;
                        default:
                            Console.WriteLine("Not a valid option");
                            break;
                    }
                    break;
                case "s":
                    UIsearch(db);
                    break;
                case "a":
                    UIaddCustomer(db);
                    break;
                default:
                    break;

            }
            Console.WriteLine("Need to (p)rint, (s)earch for customers, (a)dd a customer");
            Console.WriteLine("Type 'q' to quit");

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
        public static void printInventory(DataBase db)
        {
            db.PrintStores(db);
            Console.WriteLine("Choose a store number: ");
            db.searchStoreInventory(Convert.ToInt32(Console.ReadLine()));
        }
        public static void printOrderHistory(DataBase db)
        {
            db.PrintStores(db);
            Console.WriteLine("Choose a store number: ");
            db.searchStoreOrder(Convert.ToInt32(Console.ReadLine()));
        }
        public static void UIsearch(DataBase db)
        {
            Console.WriteLine("What do you want to search for? (c)ustomer or (o)rders of a customer:");
            string choice = Console.ReadLine().ToLower();

            switch(choice)
            {
                case "c":
                    customerSearch(db);
                    break;
                default:
                    break;


            }
        }
        public static void customerSearch(DataBase db)
        {
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

        public static void addSampleData(DataBase db)
        {
            Store Walmart = new Store(99999);
            Store Target = new Store(99999);

            db.AddStore(Walmart);
            db.AddStore(Target);

            //adding inventory
            db[0].AddInventory(new Product(1, "orange", 3, 21.12));
            db[0].AddInventory(new Product(2, "bannanna", 123, .68));
            db[0].AddInventory(new Product(3, "Bread", 3, 21.12));
            db[0].AddInventory(new Product(4, "Milk", 23, 3.00));
            db[0].AddInventory(new Product(5, "Water", 5, 3.00));


            //adding customers
            db.AddCustomer(new Customer("JJ", "who", "lf@gmail.com", "877-CASH-NOW"));
            db.AddCustomer(new Customer("Jordan", "James", "lf@gmail.com", "877-CASH-NOW"));
            db.AddCustomer(new Customer("JJ", "James", "lf@gmail.com", "877-CASH-NOW"));
            db.AddCustomer(new Customer("Jakup", "James", "lf@gmail.com", "877-CASH-NOW"));
            db.AddCustomer(new Customer("Jonathan", "James", "lf@gmail.com", "877-CASH-NOW"));
            db.AddCustomer(new Customer("JJ", "gabs", "lf@gmail.com", "877-CASH-NOW"));


            // making order
            Order newOrder = new Order(db[0].getId(), "JJ", "James");
            newOrder.addItem(db[0].getInventory(0), 4);
            newOrder.addItem(db[0].getInventory(1), 2);

            // adding Order
            db[0].AddOrder(newOrder);

            db.AddCustomer(new Customer("Joseph", "Joestar", "jj@gmail.com", "733-343-2314"));
            ///making order
            Order Order2 = new Order(db[0].getId(), "Joseph", "Joestar");
            Order2.addItem(db[0].getInventory(3), 2);
            Order2.addItem(db[0].getInventory(4), 2);

            //adding order
            db[0].AddOrder(Order2);

        }

    }

}
