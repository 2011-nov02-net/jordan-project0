using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Library
{
    public class Customer
    {
        public int CustomerId { get; set; }
        private static int customerIDSeed = 1;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    
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
        public string getCustomer()
        {
            return $"{CustomerId} {FirstName} {LastName} | {Email} | {Phone}";
        }


    }
}
