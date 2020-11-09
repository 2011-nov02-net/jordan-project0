using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Library
{
    public class DataBase
    {
        private List<Store> database = new List<Store>();

        public void addStore(Store store)
        {
            database.Add(store);
        }
        public DataBase()
        {

        }
        public Store this[int index]
        {
            get
            {
                return database[index];
            }
        } 
    }
}
