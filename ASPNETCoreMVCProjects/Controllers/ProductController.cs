using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class ProductController : Controller
    {

        // Static in memory list to store product data

        private static List<Product> products = new List<Product>();

        //GET: Display form and submitted products
        [HttpGet]
        public IActionResult Create()
        {
            var orderedProducts = products.OrderByDescending(e => e.Id).ToList();

            var totalInventory = orderedProducts.Sum(p=>p.Price * p.Quantity);

            var model = new ProductViewModel
            {
                //Show products latest first
                Products = orderedProducts,
                TotalInventoryValue = totalInventory
            };
            return View(model);
        }

        //POST: Accept form submission
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                products.Add(product);
            }

            var orderedProducts = products.OrderByDescending(e => e.Id).ToList();
            var totalInventory = orderedProducts.Sum(p => p.Price * p.Quantity);
            var model = new ProductViewModel
            {
                Products = orderedProducts,
                TotalInventoryValue = totalInventory,
                LatestProductId = product.Id
            };
            return View(model);
        }
    }



    //View Model to combine form data and list of products
    public class ProductViewModel
    {
        //Form input
        public Product Product { get; set; } = new Product();
        //List of all products
        public List<Product> Products { get; set; } = new List<Product>();
        public decimal TotalInventoryValue { get; set; }
        //ID of the latest product for highlighting
        public int LatestProductId { get; set; } = 0;
    }
}
