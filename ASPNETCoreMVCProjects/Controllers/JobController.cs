using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class JobController : Controller
    {
        // Static list of job applications

        private static List<Job> jobs = new List<Job>();

        public IActionResult Index(string positionFilter)
        {
            ViewBag.Positions = jobs.Select(j=>j.Position).Distinct().ToList();
            ViewBag.SelectedPosition = positionFilter;

            var filtered = string.IsNullOrEmpty(positionFilter)
                ?jobs
                :jobs.Where(j=>j.Position == positionFilter).ToList();

            return View(filtered.OrderByDescending(j => j.ApplicationId).ToList());
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                //Auto increment authorid
                job.ApplicationId = jobs.Count > 0 ?
                    jobs.Max(j => j.ApplicationId) + 1 : 1;

                jobs.Add(job);
                return RedirectToAction("Index");
            }
            return View(job);
        }
    }
}
