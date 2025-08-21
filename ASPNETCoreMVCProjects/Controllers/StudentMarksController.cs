using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class StudentMarksController : Controller
    {
        private static List<StudentMarks> marksList = new List<StudentMarks>();

        public IActionResult Index()
        {
            if (marksList.Count > 0)
            {
                int highest = marksList.Max(m => m.Marks);
                ViewBag.Highest = highest;
            }
            else
            {
                ViewBag.Highest = 0;
            }

            return View(marksList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentMarks studentMark)
        {
            if (ModelState.IsValid)
            {
                // Auto increment StudentId
                studentMark.StudentId = marksList.Count > 0 ? marksList.Max(s => s.StudentId) + 1 : 1;
                marksList.Add(studentMark);
                return RedirectToAction("Index");
            }
            return View(studentMark);
        }
    }
}
