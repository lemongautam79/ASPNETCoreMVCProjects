
using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class QuizController : Controller
    {
        // Static in memory list to store Quiz data
        private static List<Quiz> quizes = new List<Quiz>();

        //GET: Display form and submitted quizes
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new QuizViewModel
            {
                Quizes = quizes.OrderByDescending(q => q.Score).ToList(),
            };
            return View(viewModel);
        }

        // POST: Accept form submission
        [HttpPost]
        public IActionResult Create(Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                quizes.Add(quiz);
            }

            var model = new QuizViewModel
            {
                Quizes = quizes.OrderByDescending(q => q.Score).ToList(),
                LatestQuizId = quiz.Id
            };
            return View(model);
        }
    }

    // View Model to combine form data and list of quizes
    public class QuizViewModel
    {
        //Form Input
        public Quiz Quiz { get; set; } = new Quiz();

        //List all quizes
        public List<Quiz> Quizes { get; set; } = new List<Quiz>();

        public int LatestQuizId { get; set; } = 0;
    }
}
