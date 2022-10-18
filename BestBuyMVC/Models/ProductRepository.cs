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

        // Get Category //
        public IEnumerable<Category> GetCategories()
        {
            return _connection.Query<Category>("SELECT * FROM categories;");
        }
        // Assign a Category //
        public Product AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;
            return product;
        }
        // Insert A Product //
        public void InsertProduct(Product productToInsert)
        {
            _connection.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
                new { name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });
        }

        // Delete A Product //
        public void DeleteProduct(Product product)
        {
            _connection.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;", new { id = product.ProductID });
            _connection.Execute("DELETE FROM Sales WHERE ProductID = @id;", new { id = product.ProductID });
            _connection.Execute("DELETE FROM Products WHERE ProductID = @id;", new { id = product.ProductID });
        }

    }
}