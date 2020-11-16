using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.Library;
using StoreApp.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace StoreApp.AppConsole
{
    class StoreRepository
    {
        private readonly DbContextOptions<StoreDBContext> _contextOptions;
        /// <summary>
        /// Get All Stores and return them to a List
        /// </summary>
        /// <returns></returns>
        public List<Library.Store> GetAllStores()
        {

                // set up db connection
                using var context = new StoreDBContext(_contextOptions);

                var dbStore = context.Stores.ToList();
                // turn the select statement into a list of stores
                var appStore = dbStore.Select(s => new Library.Store(s.StoreId, s.Name, s.Street, s.City, s.Zip)).ToList();
                return appStore;

        }
        /// <summary>
        /// Gets all Custoemrs and turns them into a list
        /// </summary>
        /// <returns></returns>
        public List<Library.Customer> GetAllCustomers()
        {
            // set up db connection
            using var context = new StoreDBContext(_contextOptions);

            var dbCustomer= context.Customers.ToList();
            var appCustomer = dbCustomer.Select(s => new Library.Customer(s.CustomerId, s.FirstName, s.LastName, s.Email, s.Phone)).ToList();
            return appCustomer;
        }
        public Library.Store GetInventory(int id)
        {
            using var context = new StoreDBContext(_contextOptions);

            // include the products and the prices in inventory
            var dbInventory = context.Inventories
                                        .Include(i => i.Product)
                                        .ThenInclude(i => i.Prices);

            // initialize a store with an id number
            var store = new Library.Store(id);

            // look inside dbinventory
            foreach (var inventory in dbInventory)
            {
                // wont let me do .First i'll have to ask nick why
                if (inventory.StoreId == id)
                {
                    // turn the price datatype to a list
                    var PriceList = inventory.Product.Prices.ToList();
                    // should grab the newest price in price list
                    var price = PriceList[PriceList.Count-1].Price1;
                    // add to the Inventory class
                    store.AddInventory(new Library.Product(inventory.Product.ProductId, inventory.Product.Name, (int)inventory.Quantity, (double)price));
                }
            }
            // return this mess.
            return store;
        }
        public Library.Store GetOrderHistoryOfStore(int id)
        {
            using var context = new StoreDBContext(_contextOptions);
            var dbOrderHitory = context.CustomerOrders.Include(c => c.Customer);
            var stores = new Library.Store(id);
            foreach(var order in dbOrderHitory)
            {
                if (order.StoreId == id)
                {
                    var time = order.TransactionTime;
                    stores.AddOrder(new Order(order.TransactionNumber, id, order.CustomerId, order.Customer.FirstName, order.Customer.LastName, order.TransactionTime.ToString()));
                }
            }
            return stores;
        }
        public Library.DataBase GetOrderHistoryOfCustomer(int id)
        {
            using var context = new StoreDBContext(_contextOptions);
            var dbOrderHitory = context.CustomerOrders.Include(c => c.Customer);
            var customer = new Library.DataBase(new Library.Customer(id));
            foreach (var order in dbOrderHitory)
            {
                if (order.CustomerId == id)
                {
                    customer.AddOrder(new Order(order.TransactionNumber, id, order.CustomerId, order.Customer.FirstName, order.Customer.LastName, order.TransactionTime.ToString()));
                }
            }
            return customer;
        }

        public Library.DataBase GetOrder(int id)
        {
            using var context = new StoreDBContext(_contextOptions);
            var dbOrderHitory = context.CustomerOrders.Include(c => c.ProductOrdereds)
                .ThenInclude(c => c.Product)
                .ThenInclude(c => c.Prices);
            var db = new Library.DataBase(new Library.Store(id));
            foreach (var orders in dbOrderHitory)
            {

                if (orders.TransactionNumber == id)
                {
                    var x = orders.TransactionTime.ToString();
                    Library.Order order = new Library.Order(id, orders.StoreId, orders.CustomerId, x);
                    foreach(var item in orders.ProductOrdereds)
                    {
                        var price = item.Product.Prices.ToList();
                        var tPrice = price[0].Price1;
                        order.addItem(new Library.Product(item.ProductId, item.Product.Name, (int)item.Quantity, (double)tPrice));
                    }
                    db.AddOrder(order);
                }

            }
            return db;
        }
        public StoreRepository (DbContextOptions<StoreDBContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }
    }
}
