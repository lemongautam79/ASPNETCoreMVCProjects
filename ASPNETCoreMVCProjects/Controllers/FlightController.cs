using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class FlightController : Controller
    {
        private static List<Flight> flights = new List<Flight>();

        [HttpGet]
        public IActionResult Create()
        {
            var furthestReservations = flights.OrderByDescending(e => e.FlightDate).ToList();

            var model = new FlightViewModel
            {
                Flights = furthestReservations
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Flight flight)
        {
            if (ModelState.IsValid)
            {
                flights.Add(flight);
            }

            var furthestReservation = flights.OrderByDescending(e => e.FlightDate).ToList();

            var model = new FlightViewModel
            {
                Flights = furthestReservation,
                LatestFlightId = flight.ReservationId
            };

            return View(model);
        }
    }

    public class FlightViewModel
    {
        public Flight Flight { get; set; }

        public List<Flight> Flights { get; set; } = new List<Flight>();

        public int LatestFlightId { get; set; } = 0;
    }
}
