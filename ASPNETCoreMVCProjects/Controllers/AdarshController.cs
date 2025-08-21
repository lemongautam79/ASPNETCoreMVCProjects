using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class AdarshController : Controller
    {
        // Static in memory list to store adarsh data
        private static List<Adarsh> adarsh = new List<Adarsh>();

        // GET : Display all form data
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}