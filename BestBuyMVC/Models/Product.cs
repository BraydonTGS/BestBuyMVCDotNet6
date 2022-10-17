using System;

namespace BestBuyMVC.Models
{
    public class Product
    {
        // Create the Model First //
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int OnSale { get; set; }
        public int StockLevel { get; set; }

        public Product()
        {
        }
    }
}

