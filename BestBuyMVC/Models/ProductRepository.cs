using System;
using System.Data;
using Dapper;

namespace BestBuyMVC.Models
{
    public class ProductRepository : IProductReository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        // Gets All Products: Using Dapper: From the BB DB, Returns a Collection of Ienumerable<Products> //
        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products p ORDER BY p.ProductId;");
        }
    }
}