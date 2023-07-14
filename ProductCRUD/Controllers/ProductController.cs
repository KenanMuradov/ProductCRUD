using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductCRUD.Models;
using ProductCRUD.Models.ViewModels;

namespace ProductCRUD.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _products = new();
        private static IMapper _mapper;
        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }
        // 898756bc-56a8-415f-a1b3-a71b8afa9c29
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
                ViewData["id"] = product?.Id;
                if (product != null)
                    return View(_mapper.Map<Product, ProductViewModel>(product));
                else
                    return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel product, Guid? id)
        {
            if (id is null)
            {
                var newProduct = _mapper.Map<Product>(product);
                _products.Add(newProduct);
            }
            else
            {
                var index = _products.IndexOf(_products.Find(p => p.Id == id)!);
                _mapper.Map(product, _products[index]);
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
