using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.Library.Printer;
using StoreApp.Library.Location.Search;



namespace StoreApp.Library
{
    public class DataBase
    {
        private readonly IPrint print = new PrinterConsole();
        private List<Store> database = new List<Store>();
        private List<Customer> customers = new List<Customer>();


        // return store database by index
        public Store this[int index]
        {
            get
            {
                return database[index];
            }
        }


        //Store methods
        public void AddStore(Store store) => database.Add(store);
        public void PrintStores(DataBase db) => print.PrintStores(database);


        // customer methods
        public void printCustomers() =>print.PrintCustomers(customers);
        public void AddCustomer(Customer customer) => customers.Add(customer);
        public string customerSearchFirstName(string fName) => SearchCustomers.customerSearchFirstName(customers, fName);
        public string customerSearchLastName(string lName) => SearchCustomers.customerSearchLastName(customers, lName);
        public string customerSearchID(string id) => SearchCustomers.customerSearchFirstName(customers, id);
        public void searchStoreInventory(int id)=> SearchStore.ReturnStoreInventory(database, id);
        public void searchStoreOrder(int id) => SearchStore.ReturnStoreOrderHistory(database, id);
    }
}
