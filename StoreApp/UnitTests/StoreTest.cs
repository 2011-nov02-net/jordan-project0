using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using StoreApp.Library;

namespace UnitTests
{
    public class StoreTest
    {
        [Fact]
        public void isValid()
        {
            // set up the variables.
            DataBase db = new DataBase();
            db.AddStore(new Store(1, "Walmart", "tx", "Waterburg dr", "Springfield", "34295"));

            bool Valid = db[0].isValid();

            Assert.True(Valid);
        }
        [Fact]
        public void hasInventory()
        {
            // set up the variables.
            DataBase db = new DataBase();
            db.AddStore(new Store(1));
            db.AddStore(new Store(2));

            db[1].AddInventory(new Product(1, "apple", 2, 12));

            Assert.False(db[0].hasInventory());
            Assert.True(db[1].hasInventory());

        }
        [Fact]
        public void notValid()
        {
            // set up the variables.
            DataBase db = new DataBase();
            db.AddStore(new Store(1));

            Assert.False(db[0].isValid());

        }
        [Fact]
        public void addStore()
        {
            // set up the variables.
            DataBase db = new DataBase();
            db.AddStore(new Store(1));
            db.AddStore(new Store(2));

            var indexedStore = db[0];

            Assert.Equal(db.Stores[0], indexedStore);
            Assert.Equal(2, db.Stores.Count);
        }

    }
}
