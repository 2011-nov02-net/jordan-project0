using StoreApp.Library;
using StoreApp.DataModel;
using System;
using System.Collections.Generic;
using StoreApp.Library.Location.Serialize;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;

namespace StoreApp.AppConsole
{
    class Program
    {
        // 
        static DbContextOptions<StoreDBContext> s_dbContextOptions;

        static void Main(string[] args)
        {
            // grab connection string and deserialize it
            string connectionString =  ReadData.GetConnectionString();

            // log in using sql server
            using var logStream = new StreamWriter("ef-logs.txt");

            var optionsBuilder = new DbContextOptionsBuilder<StoreDBContext>();
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.LogTo(logStream.WriteLine, LogLevel.Information);

            s_dbContextOptions = optionsBuilder.Options;
            StoreRepository db = new StoreRepository(s_dbContextOptions);

            SqlConsoleUi.mainMenu(db);

        }

    }

}