using System;
namespace BestBuyMVC.Models
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
    }
}

