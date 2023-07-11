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

        public IActionResult AddProduct(Guid? id)
        {
            if (id == null)
                return View();
            else
            {
                var product = _products.Find(p => p.Id == id);
                return View(product);
            }

        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (product.Id is null)
            {
                product.Id = Guid.NewGuid();
                _products.Add(product);
            }
            else
            {
                var index = _products.IndexOf(_products.Find(p => p.Id == product.Id)!);
                _products[index] = product;
            }
            return RedirectToAction("Index");
        }

        public IActionResult GetProduct(string searchProperty)
        {
            Product? product = null;
            if (Guid.TryParse(searchProperty, out Guid id))
            {
                product = _products.Find(p => p.Id == id);
            }
            else
            {
                product = _products.Find(p => p?.Name?.ToLower() == searchProperty.Trim().ToLower());
            }
            return View(product);
        }

        public IActionResult DeleteProduct(Guid id)
        {
            Product? product = null;
            product = _products.Find(p => p.Id == id);

            if (product != null)
            {
                _products.Remove(product);
            }
            return RedirectToAction("Index");
        }
    }
}
