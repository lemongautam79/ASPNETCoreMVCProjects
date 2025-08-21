using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class AdarshController : Controller
    {
        // Static in memory list to store adarsh data
        private static List<Adarsh> adarshs = new List<Adarsh>();

        [HttpGet]
        public IActionResult Create()
        {
            var model = new AdarshViewModel
            {
                //Show employees latest first
                Adarshs = adarshs.OrderByDescending(e => e.ID).ToList(),
            };
            return View(model);
        }

        //POST: Accept form submission
        [HttpPost]
        public IActionResult Create(Adarsh adarsh)
        {
            if (ModelState.IsValid)
            {
                // Add adarsh to the in memory list
                adarshs.Add(adarsh);
            }
            var model = new AdarshViewModel
            {
                //Show employees latest first
                Adarshs = adarshs.OrderByDescending(e => e.ID).ToList(),
                LatestAdarshId = adarsh.ID // Set the latest employee ID for highlighting
            };
            return View(model);
        }

    }

    //View Model to combine form data and list of adarsh
    public class AdarshViewModel
    {
        //Form input
        public Adarsh Adarsh { get; set; } = new Adarsh();

        //List of all adarsh
        public List<Adarsh> Adarshs { get; set; } = new List<Adarsh>();

        //ID of the latest student for highlighting
        public int LatestAdarshId { get; set; } = 0;
    }
}