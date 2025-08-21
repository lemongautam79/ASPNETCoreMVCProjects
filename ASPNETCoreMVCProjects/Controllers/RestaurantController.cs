using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class RestaurantController : Controller
    {
        //Static in memory list to share orders data
        private static List<Restaurant> restaurants = new List<Restaurant>();

        //GET: Display form and submitted restaurant orders
        [HttpGet]
        public IActionResult Create()
        {
            var orderedItems = restaurants.OrderByDescending(r => r.Id).ToList();
            var totalPrice = orderedItems.Sum(r => r.Price * r.Quantity);
            var model = new RestaurantViewModel
            {
                //Show latest order first
                Restaurants = orderedItems,
                TotalPrice = totalPrice
            };
            return View(model);
        }
        //POST: Accept form submission
        [HttpPost]
        public IActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                restaurants.Add(restaurant);
            }
            var orderedItems = restaurants.OrderByDescending(r => r.Id).ToList();
            var totalPrice = orderedItems.Sum(r => r.Price * r.Quantity);
            var model = new RestaurantViewModel
            {
                Restaurants = orderedItems,
                TotalPrice = totalPrice,
                LatestRestaurantId = restaurant.Id
            };
            return View(model);
        }
    }
    // View Model to combine form data and list of restaurant orders
    public class RestaurantViewModel
    {
        //Form Input
        public Restaurant Restaurant { get; set; } = new Restaurant();
        //List of restaurant orders
        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
        //Total price of all orders
        public decimal TotalPrice { get; set; } = 0;
        //Id of the latest order for highlighting
        public int LatestRestaurantId { get; set; } = 0;
    }
}
