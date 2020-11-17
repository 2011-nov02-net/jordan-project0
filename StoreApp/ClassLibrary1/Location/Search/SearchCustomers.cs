using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Library.Location.Search
{
    public class SearchCustomers
    {
        /// <summary>
        /// Search a customer by their first name and return a string with each of the person's information
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="firstName"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Search a customer by their last name and return a string with each person's information
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
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
            if (String.IsNullOrEmpty(returnedCustomer))
                Console.WriteLine("No Customer with that Last Name Found");
            return returnedCustomer;
        }
        /// <summary>
        /// Search for a customer by their last name and return a customer
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Customer customerSearchID(List<Customer> customers, int id)
        {
            foreach (var person in customers)
            {
                if (person.CustomerId== id)
                {
                    var returnedCustomer = new Customer(person);
                    return returnedCustomer;
                }
            }
            Console.WriteLine("No Customer With That Name found");
            return new Customer(0);

        }
    }
}
