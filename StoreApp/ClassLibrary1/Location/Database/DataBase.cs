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
        private List<Customer> _customers = new List<Customer>();
        private List<Order> _orders = new List<Order>();
        // a database that returns nothing
        public DataBase()
        {

        }
        // initialize a database with only customers
        public DataBase(List<Store> stores)
        {
            Stores = stores;
        }
        // initialize a database with only one store
        public DataBase(Store store)
        {
            Stores.Add(store);
        }
        public DataBase(Customer customer)
        {
            Customers.Add(customer);
        }
        // initialize a database with a list of customers
        public DataBase (List <Customer> customers)
        {
            Customers = customers;
        }
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
                return _customers;
            }
            set
            {
                _customers = value;
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
        // returns the first order in the list. Useful when we have a database called with only one order.
        public Order getFirstOrder()
        {
            return _orders[0];
        }


        //Store methods
        public void AddStore(Store store) => Stores.Add(store);
        public void PrintStores() => print.PrintStores(Stores);
        public void PrintOrders() => print.PrintOrderHistory(_orders);
        public void AddOrder(Order transaction) => _orders.Add(transaction);

        // customer methods
        public void printCustomers() =>print.PrintCustomers(_customers);
        public void AddCustomer(Customer customer) => _customers.Add(customer);
        public string customerSearchFirstName(string fName) => SearchCustomers.customerSearchFirstName(_customers, fName);
        public string customerSearchLastName(string lName) => SearchCustomers.customerSearchLastName(_customers, lName);
        public Customer customerSearchID(string id) => SearchCustomers.customerSearchID(_customers, id);
        public Customer customerSearchID(List<Customer> customers, string id) => SearchCustomers.customerSearchID(customers, id);

        public void searchStoreInventory(int id)=> SearchStore.ReturnStoreInventory(Stores, id);
        public void searchStoreOrder(int id) => SearchStore.ReturnStoreOrderHistory(Stores, id);
    }
}
