using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.Library.Printer;
using StoreApp.Library.Location.Search;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks.Sources;

namespace StoreApp.Library
{
    public class DataBase
    {
        private readonly IPrint print = new PrinterConsole();
        private List<Store> _stores = new List<Store>();
        private List<Customer> customers = new List<Customer>();

        public List<Store> Stores {
            get
            {
                return _stores;
            }
            set
            {
                _stores = value;
            }
        }
        public List<Customer> Customers
        {
            get
            {
                return customers;
            }
            set
            {
                customers = value;
            }
        }
        // return store database by index
        public Store this[int index]
        {
            get
            {
                return _stores[index];
            }
        }


        //Store methods
        public void AddStore(Store store) => Stores.Add(store);
        public void PrintStores(DataBase db) => print.PrintStores(Stores);


        // customer methods
        public void printCustomers() =>print.PrintCustomers(customers);
        public void AddCustomer(Customer customer) => customers.Add(customer);
        public string customerSearchFirstName(string fName) => SearchCustomers.customerSearchFirstName(customers, fName);
        public string customerSearchLastName(string lName) => SearchCustomers.customerSearchLastName(customers, lName);
        public string customerSearchID(string id) => SearchCustomers.customerSearchFirstName(customers, id);
        public void searchStoreInventory(int id)=> SearchStore.ReturnStoreInventory(Stores, id);
        public void searchStoreOrder(int id) => SearchStore.ReturnStoreOrderHistory(Stores, id);
    }
}
