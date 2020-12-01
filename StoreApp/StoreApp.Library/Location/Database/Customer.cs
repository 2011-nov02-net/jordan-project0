using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Library
{
    /// <summary>
    /// Customer class which holds different ways to call a customer
    /// includes search methdos and print methods. Each customer requires a Name
    /// </summary>
    public class Customer
    {
        public int CustomerId { get; set; }
        private static int customerIDSeed = 1;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    
        public Customer(Customer customer) {
            CustomerId = customer.CustomerId;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            Phone = customer.Phone;
        }
        public Customer(string fName, string lName, string email, string phone)
        {
            CustomerId = customerIDSeed;
            FirstName = fName;
            LastName = lName;
            Email = email;
            Phone = phone;
            customerIDSeed++;
        }
        public Customer(int id, string fName, string lName, string email, string phone)
        {
            CustomerId = id;
            FirstName = fName;
            LastName = lName;
            Email = email;
            Phone = phone;
            customerIDSeed = CustomerId+1;
        }
        public Customer(int id)
        {
            CustomerId = id;
        }
        /// <summary>
        /// Checks if the customer is a valid customer to be implimentd into the database
        /// </summary>
        /// <returns>A bool that will say is valid or not valid</returns>
        public bool isValid()
        {
            // if any of the 4 required datatypes are empty return false, otherwise return true.
            // also include if phone number is not less than ten
            if (String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(LastName) || String.IsNullOrEmpty(Email) || String.IsNullOrEmpty(Phone))
            {
                return false;
            }
            return true;
        }
        public string getCustomer()
        {
            return $"ID: {CustomerId} | First Name: {FirstName} | Last Name: {LastName} | Email: {Email} | Phone: {Phone}";
        }


    }
}
