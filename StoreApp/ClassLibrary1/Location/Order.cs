using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace StoreApp.Library
{
    public class Order
    {
        private int StoreId { get; set; }
        private string CustFirstName { get; set; }
        private string CustLastName { get; set; }
        private List<Product> items = new List<Product>();
        private string _timeStamp { get; set; }
        private string setTime()
        {
                DateTime localDate = DateTime.Now;
                return localDate.ToString();
        }
        private double Cost
        {
            get
            {
                double _cost = 0;
                foreach (Product item in items) {
                    _cost += item.getPrice();
                }
                return _cost;
            }
        }
        public void addItem( Product item)
        {
            items.Add(item);
        }
        public Order(int storeId, string custFirstName, string custLastName)
        {
            StoreId = storeId;
            CustFirstName = custFirstName;
            CustLastName = custLastName;
            _timeStamp = setTime();

        }
        public Order(int storeId, string custFirstName, string custLastName, string time)
        {
            StoreId = storeId;
            CustFirstName = custFirstName;
            CustLastName = custLastName;
            _timeStamp = time;

        }
        public double GetCost()
        {
            return Cost;
        }
        public string getData() {
            return $"{StoreId}";
        }
    }
}
