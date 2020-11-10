using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Library
{
    public class Customer
    {
        private static int customerIDSeed = 0;
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Email { get; set; }
        private string Phone { get; set; }
        private string ID { get; set; }

        public string GetFirstName() => FirstName;
        public string GetLastName() => LastName;
        public string getPhone() => Phone;
        public string getID() => ID;
    
        public Customer(string fName, string lName, string email, string phone)
        {
            ID = customerIDSeed.ToString();
            FirstName = fName;
            LastName = lName;
            Email = email;
            Phone = phone;

        }
        public Customer(string id, string fName, string lName, string email, string phone)
        {
            ID = id;
            FirstName = fName;
            LastName = lName;
            Email = email;
            Phone = phone;
        }

        public string getCustomer()
        {
            return $"{ID} {FirstName} {LastName} | {Email} | {Phone}";
        }


    }
}
