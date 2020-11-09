﻿using StoreApp.Library;
using System;
using System.Collections.Generic;

namespace StoreApp.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Store Walmart = new Store(99999);
            UserIntrerface.addSampleData(Walmart);

            Console.WriteLine("at the main Menu type 'h' for help or 'q' to quit.");

            string userInput = Console.ReadLine();

            while (userInput != "q")
            {
                UserIntrerface.selectScreen(Walmart, userInput);
                userInput = Console.ReadLine();
            }

        }
    }
}