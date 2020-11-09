using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.Library;
using StoreApp.Library.Printer;

namespace StoreApp.AppConsole
{
    public class UserIntrerface
    {
       public static void selectScreen(Store store, string choice) {
            string choice2;
            switch (choice)
            {
                case "p":
                    Console.WriteLine("Entering Print Menu");
                    Console.WriteLine("Want to print (i)nventory, (c)ustomers, (o)rders");
                    choice2 = Console.ReadLine();
                    switch (choice2) {
                        case "i":
                            store.printInventory();
                            break;
                        case "c":
                            store.printCustomers();
                            break;
                        case "o":
                            store.printOrders();
                            break;
                        default:
                            break;

                    }
                    break;
                case "a":
                    Console.WriteLine("Entering Adding Menu");
                    Console.WriteLine("Want to add (i)nventory, (c)ustomers, (o)rders");
                    choice2 = Console.ReadLine();
                    switch(choice2)
                    {
                        case "c":
                            UIaddCustomer(store);
                            break;
                        case "i":
                            break;
                        case "o":
                            break;
                    }
                    break;
                case "s":
                    break;
                default:
                    Console.WriteLine("Type 'q' to quit");
                    break;

            }

        }
        public static void UIaddCustomer(Store store)
        {
            Console.WriteLine("Enter Customer's First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Customer's Last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Customer's Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Customer's Phone: ");
            string phone = Console.ReadLine();
            store.AddCustomer(new Customer(firstName, lastName, email, phone));

        }
        public static void addSampleData(DataBase db)
        {
            Store Walmart = new Store(99999);
            Store Target = new Store(99999);

            db.addStore(Walmart);
            //adding inventory
            db[0].AddInventory(new Product(1, "orange", 3, 21.12));
            db[0].AddInventory(new Product(2, "bannanna", 123, .68));
            db[0].AddInventory(new Product(1, "Bread", 3, 21.12));
            db[0].AddInventory(new Product(2, "Milk", 23, 3.00));
            db[0].AddInventory(new Product(2, "Water", 5, 3.00));


            //adding customers
            db[0].AddCustomer(new Customer("Luke", "Fisher", "lf@gmail.com", "877-CASH-NOW"));


            // making order
            Order newOrder = new Order(db[0].getId(), "Luke", "Fisher");
            newOrder.addItem(db[0].getInventory(0), 4);
            newOrder.addItem(db[0].getInventory(1), 2);

            // adding Order
            db[0].AddOrder(newOrder);

            db[0].AddCustomer(new Customer("Joseph", "Joestar", "jj@gmail.com", "733-343-2314"));
            ///making order
            Order Order2 = new Order(db[0].getId(), "Joseph", "Joestar");
            Order2.addItem(db[0].getInventory(3), 2);
            Order2.addItem(db[0].getInventory(4), 2);

            //adding order
            db[0].AddOrder(Order2);

        }

    }

}
