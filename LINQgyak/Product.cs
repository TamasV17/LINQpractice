using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQgyak
{
    internal class Product
    {
        public Product(string name, string brand, int price, DateTime dateTime, int amountOnStock)
        {
            Name = name;
            Brand = brand;
            Price = price;
            DateTime = dateTime;
            AmountOnStock = amountOnStock;
        }

        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public DateTime DateTime { get; set; }
        public int AmountOnStock { get; set; }
    }
}
