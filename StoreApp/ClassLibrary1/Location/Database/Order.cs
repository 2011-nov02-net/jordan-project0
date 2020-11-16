using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace StoreApp.Library
{
    public class Order
    {
        public int TransactionNumber{get; private set;}
        public int StoreId { get; private set; }
        public int CustomerId { get; set; }
        public string CustFirstName { get; set; }
        public string CustLastName { get; set; }
        public string _timeStamp { get; private set; }

        public string TimeStamp
        {
            set
            {
                _timeStamp = value;
            }
        }
        
        private List<Product> items = new List<Product>();

        private static int transactionNumberSeed =21312345;
        public double Cost
        {
            get
            {
                double _cost = 0;
                foreach (Product item in items)
                {
                    _cost += item.Price * item.Quantity;
                }
                return _cost;
            }
        }
        public List<Product> Items => items;

        private string setTime()
        {
                DateTime localDate = DateTime.Now;
                return localDate.ToString();
        }

        public void addItem( Product item, int quanity)
        {
            Product boughtItem = new Product(item, quanity);
            if (item.Quantity >= quanity)
            {
                item.updateQuantity(-quanity);
                Console.WriteLine("item Added Successfully");
            }
            else
            {
                boughtItem.updateQuantity(-quanity);
                Console.WriteLine("Item not added, not enough in inventory");
            }

            items.Add(boughtItem);
        }
        public void addItem(Product item)
        {
            items.Add(item);
        }
        /// <summary>
        /// A constructor for orders that are new
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="custFirstName"></param>
        /// <param name="custLastName"></param>
        public Order(int storeId, string custFirstName, string custLastName)
        {

            StoreId = storeId;
            CustFirstName = custFirstName;
            CustLastName = custLastName;
            transactionNumberSeed = transactionNumberSeed + 1;
            TransactionNumber = transactionNumberSeed;

            _timeStamp = setTime();

        }
        /// <summary>
        /// A cunstructor for orders taht are read
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="custFirstName"></param>
        /// <param name="custLastName"></param>
        /// <param name="time"></param>
        public Order(int storeId, string custFirstName, string custLastName, string time)
        {
            StoreId = storeId;
            CustFirstName = custFirstName;
            CustLastName = custLastName;
            _timeStamp = time;
            transactionNumberSeed = transactionNumberSeed + 1;
            transactionNumberSeed++;

        }
        public Order(int transactionId,  int storeId, int customerId , string custFirstName, string custLastName, string time)
        {
            TransactionNumber = transactionId;
            StoreId = storeId;
            CustomerId = customerId;
            CustFirstName = custFirstName;
            CustLastName = custLastName;
            _timeStamp = time;
            transactionNumberSeed = transactionNumberSeed + 1;
            transactionNumberSeed++;

        }
        /// <summary>
        /// 
        /// </summary>
        public Order(int transactionId, int storeId, int customerId, string time)
        {
            TransactionNumber = transactionId;
            StoreId = storeId;
            CustomerId = customerId;
            TimeStamp = time;

        }
        /// <summary>
        /// Have an order that only needs the transaction number
        /// </summary>
        public Order(int id)
        {
            TransactionNumber = id;
        }

        // returns the first name
        public string getFirstName()
        {
            return CustFirstName;
        }
        // returns the last name
        public string getLastName()
        {
            return CustLastName;
        }
        public override string ToString() {
            string data = "";
            data = $"Store: {StoreId} | Transaction Number: {TransactionNumber} | {_timeStamp} | Customer ID: {CustomerId} | Cost: ${Cost}";
            foreach (var item in items)
            {
                data += "\n    " + item.ToString();
            }
            return data;
        }
    }
}
