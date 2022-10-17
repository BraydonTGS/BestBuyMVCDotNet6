using System;
namespace BestBuyMVC.Models
{
    public interface IProductReository
    {
        public IEnumerable<Product> GetAllProducts();
    }
}

