using StoreApp.Library.Printer;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace StoreApp.Library.Location.Search
{
    class SearchStore
    {
        public static void ReturnStoreInventory(List<Store> stores, int storeId)
        {
            foreach (var store in stores)
            {
                if (store.StoreID == storeId)
                    store.printInventory();

            }
        }
        public static void ReturnStoreOrderHistory(List<Store> stores, int storeId)
        {
            foreach (var store in stores)
            {
                if (store.StoreID == storeId)
                    store.printOrders();
            }

        }
    }
}