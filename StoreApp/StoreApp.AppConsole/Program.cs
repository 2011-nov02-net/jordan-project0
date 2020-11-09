using StoreApp.Library;
using System;
using System.Collections.Generic;

namespace StoreApp.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase db = new DataBase();
            UserIntrerface.addSampleData(db);

            Console.WriteLine("at the main Menu type 'h' for help or 'q' to quit.");

            string userInput = Console.ReadLine();

            while (userInput != "q")
            {
                UserIntrerface.selectScreen(db[0], userInput);
                userInput = Console.ReadLine();
            }

        }
    }
}