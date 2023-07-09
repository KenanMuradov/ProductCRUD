using Microsoft.AspNetCore.Mvc;
using ProductCRUD.Models;

namespace ProductCRUD.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _products = new();

        public IActionResult Index()
        {
            return View(_products);
        }

        [HttpGet]
        public IActionResult AddProduct() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult SearchProduct()
        {
            return View();
        }

        public IActionResult GetProduct(string searchProperty)
        {
            Product? product = null;
            if (int.TryParse(searchProperty, out int id))
            {
                product = _products.Find(p => p.Id == id);
            }
            else
            {
                product = _products.Find(p => p?.Name?.ToLower() == searchProperty.Trim().ToLower());
            }
            return View(product);
        }
    }
}
