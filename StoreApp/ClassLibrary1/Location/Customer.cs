using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Library
{
    public class Customer
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Email { get; set; }
        private string Phone { get; set; }

        public Customer(string fName, string lName, string email, string phone)
        {
            FirstName = fName;
            LastName = lName;
            Email = email;
            Phone = phone;

        }
        public string getCustomer()
        {
            return $"{FirstName} {LastName} | {Email} | {Phone}";
        }
    }
}
