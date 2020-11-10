using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.Library.Printer;

namespace StoreApp.Library
{
    public class Product
    {
        private int ProductID { get; set; }
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
        public Product(int productID,  string name, int quantity, double price)
        {
            ProductID = productID;
            Name = name;
            Quantity = quantity;
            _price = price;
        }
        public Product(Product item, int quantity)
        {
            this.ProductID = item.ProductID;
            this.Name = item.Name;
            this.Quantity = quantity;
            this._price = item._price;
        }
        public string getProductInfo()
        {
            return $"Product ID: {ProductID} | {Name} | Q: {Quantity} | price: {_price}";
        }
        public void updateQuantity(int amount)
        {
            Quantity += amount;
        }
        public void setQuantity(int amount)
        {
            Quantity = amount;
        }
        public int getQuantity()
        {
            return Quantity;
        }
        public int getID()
        {
            return ProductID;
        }
    }
}
