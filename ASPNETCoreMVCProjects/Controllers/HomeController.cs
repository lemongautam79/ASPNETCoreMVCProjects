using System.Diagnostics;
using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetJSONDdata()
        {
            var data = new { Name = "Lemon", Age = 22 };
            return Json(data);
        }

        public IActionResult RedirectToGoogle()
        {
            return Redirect("https://www.google.com");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
