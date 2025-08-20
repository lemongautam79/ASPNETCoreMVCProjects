using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class GymController : Controller
    {
        // Static in memory list to store gym memberships data
        private static List<Gym> gyms = new List<Gym>();

        //GET: Display form and submitted gym memberships
        [HttpGet]
        public IActionResult Create()
        {
            var model = new GymViewModel
            {
                //Show latest gym memberships first
                Gyms = gyms.OrderByDescending(e => e.Id).ToList(),
            };
            return View(model);
        }

        //POST: Accept form submission
        [HttpPost]
        public IActionResult Create(Gym gym)
        {
            if (ModelState.IsValid)
            {
                // Add gym memberships in memory list
                gyms.Add(gym);
            }
            var model = new GymViewModel
            {
                //Show gym memberships latest first
                Gyms = gyms.OrderByDescending(e => e.Id).ToList(),
                LatestGymId = gym.Id
            };
            return View(model);
        }
    }


    // View Model to combine form data and list of gym memberships
    public class GymViewModel
    {
        //Form Input
        public Gym Gym { get; set; } = new Gym();

        //List of all gym memberships
        public List<Gym> Gyms { get; set; } = new List<Gym>();

        //Id of the latest membership for highlighting
        public int LatestGymId { get; set; } = 0;
    }
}
