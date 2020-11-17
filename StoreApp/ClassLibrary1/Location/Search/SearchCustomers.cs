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
                    returnedCustomer += "\n";
                }
            }
            // if we have an empty string return a not found string
            if (String.IsNullOrEmpty(returnedCustomer))
                return "No Customer with that name found";
            // otherwise return to returning the name
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
                    returnedCustomer += "\n";

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
        public static Customer customerSearchID(List<Customer> customers, string id)
        {
            // try to parse the string if it's unparsable return a 0
            int idCheck = 0;
            bool result = int.TryParse(id, out idCheck);

            // for each person in customers check and return customer if found
            foreach (var person in customers)
            {
                if (person.CustomerId== idCheck)
                {
                    var returnedCustomer = new Customer(person);
                    return returnedCustomer;
                }
            }
            // print string customer not found return empty customer;
            Console.WriteLine("No Customer With That ID found");
            return new Customer(0);

        }
    }
}
