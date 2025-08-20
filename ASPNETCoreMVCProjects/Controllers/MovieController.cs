using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class MovieController : Controller
    {
        //Static in memory list of movie bookings data
        private static List<Movie> movies = new List<Movie>();

        //GET: Display form and submitted movie bookings
        [HttpGet]
        public IActionResult Create()
        {
            var model = new MovieViewModel
            {
                // Show latest movie bookings
                Movies = movies.OrderByDescending(s => s.Id).ToList(),
            };
            return View(model);
        }

        // POST: Accept form submission
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                // Add movie bookings to the static memory
                movies.Add(movie);
            }
            var model = new MovieViewModel
            {
                //Show latest movie bookings
                Movies = movies.OrderByDescending(e => e.Id).ToList(),
                LatestMovieBookingId = movie.Id
            };
            return View(model);
        }
        
    }

    // View Model to combine form data and list of movie tickets
       public class MovieViewModel
    {
        //Form Input
        public Movie Movie { get; set; } = new Movie();

        //List of all the movie tickets
        public List<Movie> Movies { get; set; } = new List<Movie>();

        //Id of the latest movie bookings for highlighting
        public int LatestMovieBookingId { get; set; } = 0;
    }

}
