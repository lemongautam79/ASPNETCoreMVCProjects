using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class HotelController : Controller
    {
        //Static in memory list to store hotel booking data
        private static List<Hotel> hotels = new List<Hotel>();

        //GET: Display form and submitted hotel bookings
        [HttpGet]
        public IActionResult Create()
        {
            var model = new HotelViewModel
            {
                //Show hotels latest first
                Hotels = hotels.OrderByDescending(h => h.Id).ToList(),
            };
            return View(model);
        }

        //POST: Accept form submission
        [HttpPost]
        public IActionResult Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                // Add hotel booking to the in memory list
                hotels.Add(hotel);
            }
            var model = new HotelViewModel
            {
                //Show hotels latest first
                Hotels = hotels.OrderByDescending(h => h.Id).ToList(),
                LatestHotelId = hotel.Id // Set the latest hotel ID for highlighting
            };
            return View(model);
        }
    }

    //View Model to combine form data and list of hotels
    public class HotelViewModel
    {
        //Form input
        public Hotel Hotel { get; set; } = new Hotel();
        //List of all hotels
        public List<Hotel> Hotels { get; set; } = new List<Hotel>();
        //ID of the latest hotel for highlighting
        public int LatestHotelId { get; set; } = 0;
    }
}
