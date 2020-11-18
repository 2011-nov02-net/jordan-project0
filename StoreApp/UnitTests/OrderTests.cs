using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.Library;
using Xunit;


namespace UnitTests
{
    public class OrderTests
    {
        /// <summary>
        /// Checks to see if the order is valid. An Empty order should return false.
        /// </summary>
        [Fact]
        public void OrderNotValid()
        {
            // create the Order
            Order order = new Order(1,1);

            // give it the items that will be tested
            bool notvalid = order.hasItems();
            int count = order.getItems().Count;

            Assert.Equal(0, count);
            Assert.False(notvalid);
        }
        /// <summary>
        /// Checks to see if the order is valid an order with items should return true
        /// </summary>
        [Fact]
        public void OrderValid()
        {
            // set up an order with an applle in it.
            Order order = new Order(1, 1);
            Product product = new Product(1,"apple", 11, 12);
            order.addItem(product, 2);

            // create a bool to see if it has items
            // and another one to see what the count is.
            bool isValid = order.hasItems();
            int count = order.getItems().Count;

            // check the thing
            Assert.True(isValid);
            Assert.NotEqual(0, count);
        }
        /// <summary>
        /// Search the order for an item and return it.
        /// </summary>
        [Fact]
        public void searchOrder()
        {
            DataBase db = new DataBase();
            db.AddOrder(new Order(1, "Jordan", "Garcia"));
            db.AddOrder(new Order(2, "Jaden", "Johnson"));

            Product product = new Product(1, "apple", 11, 12);
            Order orderTest = db.searchStoreOrderByFName("Jordan");

            Assert.Equal("Garcia", orderTest.CustLastName);
            Assert.Equal("Jordan", orderTest.CustFirstName);
        }

    }
}
