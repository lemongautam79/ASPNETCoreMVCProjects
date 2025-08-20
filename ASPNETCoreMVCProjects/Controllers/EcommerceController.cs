using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class EcommerceController : Controller
    {

        //Static in memory list to share orders data
        private static List<Ecommerce> ecommerces = new List<Ecommerce>();

        //GET: Display form and submitted products
        [HttpGet]
        public IActionResult Create()
        {
            var orderedProducts = ecommerces.OrderByDescending(e => e.Id).ToList();

            var totalPrice = orderedProducts.Sum(p => p.Price * p.Quantity);

            var model = new EcommerceViewModel
            {
                //Show latest order first
                Ecommerces = orderedProducts,
                TotalPrice = totalPrice
            };
            return View(model);
        }

        //POST: Accept form submission
        [HttpPost]
        public IActionResult Create(Ecommerce ecommerce)
        {
            if (ModelState.IsValid)
            {
                ecommerces.Add(ecommerce);
            }

            var orderedProducts = ecommerces.OrderByDescending(e => e.Id).ToList();
            var totalPrice = orderedProducts.Sum(p => p.Price * p.Quantity);

            var model = new EcommerceViewModel
            {
                Ecommerces = orderedProducts,
                TotalPrice = totalPrice,
                LatestEcommerceId = ecommerce.Id
            };
            return View(model);
        }

    }

    // View Model to combine form data and list of orders

    public class EcommerceViewModel
    {
        //Form Input
        public Ecommerce Ecommerce { get; set; } = new Ecommerce();

        //List of orders
        public List<Ecommerce> Ecommerces { get; set; } = new List<Ecommerce>();

        public decimal TotalPrice { get; set; }

        //Id of the latest order for highlighting
        public int LatestEcommerceId { get; set; } = 0;
    }
}
