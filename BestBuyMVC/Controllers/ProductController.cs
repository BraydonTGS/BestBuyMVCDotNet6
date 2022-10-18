using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestBuyMVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BestBuyMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }


        // Get All Products Method //
        public IActionResult Index()
        {
            var products = _repo.GetAllProducts();
            return View(products);
        }

        // View Product //
        public IActionResult ViewProduct(int id)
        {
            var product = _repo.GetProduct(id);
            return View(product);
        }

        // Update Product Controller //
        public IActionResult UpdateProduct(int id)
        {
            Product prod = _repo.GetProduct(id);

            if (prod == null)
            {
                return View("ProductNotFound");
            }
            return View(prod);
        }

        // This Takes a Product to be Updated, We Update it, and then we return a Redirect //
        public IActionResult UpdateProductToDatabase(Product product)
        {
            _repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }

        // Insert Product //
        public IActionResult InsertProduct()
        {
            var prod = _repo.AssignCategory();
            return View(prod);

        }
        // Inser Product to DB //
        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            _repo.InsertProduct(productToInsert);
            return RedirectToAction("Index");

        }

        // Delete a Product //
        public IActionResult DeleteProduct(Product product)
        {
            _repo.DeleteProduct(product);
            return RedirectToAction("Index");
        }
    }

}

