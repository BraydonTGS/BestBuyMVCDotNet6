using System;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace BestBuyMVC.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        // Gets All Products: Using Dapper: From the BB DB, Returns a Collection of Ienumerable<Products> //
        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products p ORDER BY p.ProductId DESC;");
        }

        // Get a Single Product From the Product DB // Query Single Returns a Single Row //
        public Product GetProduct(int id)
        {
            return _connection.QuerySingle<Product>("SELECT * FROM Products WHERE ProductId = @id", new { id = id });
        }
        // No Return Because We are Executing //
        public void UpdateProduct(Product product)
        {
            _connection.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
            new { name = product.Name, price = product.Price, id = product.ProductID });
            // The new {} is preventing SQL injection // 
        }

    }
}