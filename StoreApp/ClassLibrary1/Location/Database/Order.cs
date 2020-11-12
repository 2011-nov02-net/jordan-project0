using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace StoreApp.Library
{
    public class Order
    {
        public int StoreId { get; set; }
        public string CustFirstName { get; set; }
        public string CustLastName { get; set; }
        private List<Product> items = new List<Product>();
        public string _timeStamp { get; set; }
        private  static int transactionNumberSeed =21312345;
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

        private int TransactionNumber{ get; set; }
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
        public Order(int storeId, string custFirstName, string custLastName)
        {
            StoreId = storeId;
            CustFirstName = custFirstName;
            CustLastName = custLastName;
            transactionNumberSeed = transactionNumberSeed + 1;
            TransactionNumber = transactionNumberSeed;

            _timeStamp = setTime();

        }
        public Order(int storeId, string custFirstName, string custLastName, string time)
        {
            StoreId = storeId;
            CustFirstName = custFirstName;
            CustLastName = custLastName;
            _timeStamp = time;
            transactionNumberSeed = transactionNumberSeed + 1;
            transactionNumberSeed++;

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
        public string getData() {
            string data = "";
            data = $"Store: {StoreId} | Transaction Number: {TransactionNumber} | {_timeStamp} | {CustFirstName} | {CustLastName} | {Cost}";
            foreach (var item in items)
            {
                data += "\n    " + item.getProductInfo();
            }
            return data;
        }
    }
}
