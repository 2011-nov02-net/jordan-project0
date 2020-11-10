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

            Console.WriteLine("at the main Menu type 'q' to quit.");
            Console.WriteLine("Need to (p)rint, (s)earch for customers, (a)dd a customer");

            string userInput = Console.ReadLine();

            while (userInput != "q")
            {
                UserIntrerface.selectScreen(db, userInput);
                userInput = Console.ReadLine();
            }

        }

    }

}