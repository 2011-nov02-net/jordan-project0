using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Library.Printer
{
    public interface IPrint
    {
        void PrintAddOrder(Order transaction);
        void PrintAddInventory();
        void PrintGetInventory(List<Product> inventory);
        void PrintCustomers(List<Customer> customers);
        void PrintOrderHistory(List<Order> orderHistory);
        void PrintCustomersOrders(List<Order> orderHistory);

    }
}
