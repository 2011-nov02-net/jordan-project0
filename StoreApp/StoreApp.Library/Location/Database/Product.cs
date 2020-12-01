using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.Library.Printer;

namespace StoreApp.Library
{
    public class Product
    {
        public int ProductID { get; private set; }
        public string Name { get; private set; }
        public double Price { get; set; }

        public int Quantity { get; set; }

        public Product(int productID,  string name, int quantity, double price)
        {
            ProductID = productID;
            Name = name;
            Quantity = quantity;
            Price = price;
        }
        public Product(Product item, int quantity)
        {
            this.ProductID = item.ProductID;
            this.Name = item.Name;
            this.Quantity = quantity;
            this.Price = item.Price;
        }
        /// <summary>
        /// Create a Product for the use of debugging
        /// </summary>
        public Product()
        {
            ProductID = 0;
        }
        public override string ToString()
        {
            return $"Product ID: {ProductID} | {Name} | Q: {Quantity} | price: {Price}";
        }
        public void updateQuantity(int amount)
        {
            Quantity += amount;
        }
        public void setQuantity(int amount)
        {
            Quantity = amount;
        }
    }
}
