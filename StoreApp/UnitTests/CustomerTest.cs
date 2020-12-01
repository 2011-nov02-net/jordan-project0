using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.Library;
using Xunit;

namespace UnitTests
{
    public class CustomerTest
    {
        /// <summary>
        /// Tests for the validity of our customers should return false
        /// </summary>
        [Fact]
        public void NotValidCustomer()
        {
            Customer NoName = new Customer(2);
            Assert.False(NoName.isValid());
        }
        /// <summary>
        /// Tests for the validity of our customers should return True
        /// </summary>
        [Fact]
        public void ValidCustoemr()
        {
            Customer hasName = new Customer(0, "Jordan", "Garcia", "jj@gmail.com", "2832239");
            Assert.True(hasName.isValid());
        }
        /// <summary>
        /// Tests to see if the Customers are Equal.
        /// </summary>
        [Fact]
        public void CustomerSearch()
        {
            DataBase db = new DataBase();
            Customer person = new Customer(1, "Nick", "Fury", "nf@gmail.com", "23143425");
            db.AddCustomer(person);

            Customer indexedPerson = db.customerSearchID("1");
                    
            Assert.Equal(person.FirstName, indexedPerson.FirstName);
            Assert.Equal(person.LastName, indexedPerson.LastName);
            Assert.Equal(person.Email, indexedPerson.Email);

        }


    }
}
