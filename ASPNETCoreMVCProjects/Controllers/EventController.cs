using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class EventController : Controller
    {
        // Static in memory data for the events
        private static List<Event> events = new List<Event>();
        private static int latestEventId = 0;

        public IActionResult Index()
        {
            //Sort by date (upcoming first)
            var sortedEvents = events.OrderBy(e => e.Date).ToList();
            ViewBag.LatestEventId = latestEventId;
            return View(sortedEvents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event newEvent)
        {
            if (ModelState.IsValid)
            {
                newEvent.EventId = events.Count > 0 ? events.Max(e => e.EventId) + 1 : 1;
                events.Add(newEvent);

                //Save the latest added
                latestEventId = newEvent.EventId;

                return RedirectToAction("Index");
            }
            return View(newEvent);
        }
    }
}
