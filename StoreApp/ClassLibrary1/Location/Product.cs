using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Library
{
    public class Product
    {
        private string Name { get; set; }
        private double _price;
        public double getPrice() {
            return _price;
        }
        private int Quantity { get; set; }


        public string getName()
        {
            return Name;
        }

        public Product(string name, int quantity, double price)
        {
            Name = name;
            Quantity = quantity;
            _price = price;
        }
        public string getProductInfo()
        {
            return $"{Name} | {Quantity} | {_price}";
        }
    }
}
