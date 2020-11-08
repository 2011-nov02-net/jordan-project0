using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.Library;
using StoreApp.Library.Printer;

namespace StoreApp.AppConsole
{
    public class UserIntrerface
    {
       public void selectScreen(Store store, string choice) {
            switch (choice)
            {
                case "p":
                    Console.WriteLine("Entering Print Menu");
                    string choice2 = Console.ReadLine();
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
                    break;
                case "s":
                    break;
                default:
                    Console.WriteLine("Type 'q' to quit");
                    break;

            }

        }
    }
}
