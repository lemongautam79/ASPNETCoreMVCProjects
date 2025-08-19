using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class CourseController : Controller
    {

        //Static in memory list to store course data
        private static List<Course> courses = new List<Course>();

        //GET: Display form and submitted courses
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CourseViewModel
            {
                // Show courses latest first
                Courses = courses.OrderByDescending(c => c.Id).ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                // Add course to the in memory list
                courses.Add(course);
            }
            var model = new CourseViewModel
            {
                // Show courses latest first
                Courses = courses.OrderByDescending(c => c.Id).ToList(),
                LatestCourseId = course.Id // Set the latest course ID for highlighting
            };
            return View(model);
        }
    }

    // View Model to combine form data and list of courses
    public class CourseViewModel
    {
        // Form input
        public Course Course { get; set; } = new Course();
        // List of all courses
        public List<Course> Courses { get; set; } = new List<Course>();
        // ID of the latest course for highlighting
        public int LatestCourseId { get; set; } = 0;
    }
}
