using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class VehicleController : Controller
    {

        // Static in memory list to store vehicle data
        private static List<Vehicle> vehicles = new List<Vehicle>();

        //GET: Display form and submitted vehicles
        [HttpGet]
        public IActionResult Create()
        {
            var model = new VehicleViewModel
            {
                // Show vehicles latest first
                Vehicles = vehicles.OrderByDescending(v => v.Id).ToList(),
            };
            return View(model);
        }

        //POST: Accept form submission
        [HttpPost]
        public IActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                // Add vehicle to the in memory list
                vehicles.Add(vehicle);
            }
            var model = new VehicleViewModel
            {
                // Show vehicles latest first
                Vehicles = vehicles.OrderByDescending(v => v.Id).ToList(),
                LatestVehicleId = vehicle.Id // Set the latest vehicle ID for highlighting
            };
            return View(model);
        }

    }

    //View Model to combine form data and list of vehicles
    public class VehicleViewModel
    {
        //Form input
        public Vehicle Vehicle { get; set; } = new Vehicle();
        //List of all vehicles
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        //ID of the latest vehicle for highlighting
        public int LatestVehicleId { get; set; } = 0;
    }
}
