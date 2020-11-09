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
        public static void addSampleData(Store store)
        {

            //adding inventory
            store.AddInventory(new Product(1, "orange", 3, 21.12));
            store.AddInventory(new Product(2, "bannanna", 123, .68));
            store.AddInventory(new Product(1, "Bread", 3, 21.12));
            store.AddInventory(new Product(2, "Milk", 23, 3.00));
            store.AddInventory(new Product(2, "Water", 5, 3.00));


            //adding customers
            store.AddCustomer(new Customer("Luke", "Fisher", "lf@gmail.com", "877-CASH-NOW"));


            // making order
            Order newOrder = new Order(store.getId(), "Luke", "Fisher");
            newOrder.addItem(store.getInventory(0), 4);
            newOrder.addItem(store.getInventory(1), 2);

            // adding Order
            store.AddOrder(newOrder);

            store.AddCustomer(new Customer("Joseph", "Joestar", "jj@gmail.com", "733-343-2314"));
            ///making order
            Order Order2 = new Order(store.getId(), "Joseph", "Joestar");
            Order2.addItem(store.getInventory(3), 2);
            Order2.addItem(store.getInventory(4), 2);

            //adding order
            store.AddOrder(Order2);

        }

    }

}
