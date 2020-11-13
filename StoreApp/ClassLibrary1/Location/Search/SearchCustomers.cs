using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Library.Location.Search
{
    class SearchCustomers
    {
        public static string customerSearchFirstName(List<Customer> customers, string firstName)
        {
            string returnedCustomer = "";
            foreach(var person in customers)
            {
                if (person.FirstName.ToLower() == firstName.ToLower())
                {
                    returnedCustomer+=person.getCustomer();
                }
            }
            return returnedCustomer;
        }
        public static string customerSearchLastName(List<Customer> customers, string lastName)
        {
            string returnedCustomer = "";
            foreach (var person in customers)
            {
                if (person.LastName == lastName)
                {
                    returnedCustomer += person.getCustomer();
                }
            }
            return returnedCustomer;
        }
        public static string customerSearchID(List<Customer> customers, string id)
        {
            string returnedCustomer = "";
            foreach (var person in customers)
            {
                if (person.CustomerId== id)
                {
                    returnedCustomer += person.getCustomer();
                }
            }
            return returnedCustomer;
        }
    }
}
