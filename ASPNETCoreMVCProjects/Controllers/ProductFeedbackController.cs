using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class ProductFeedbackController : Controller

    {
        // Static in memory list to store product feedback
        private static List<ProductFeedback> productFeedbacks = new List<ProductFeedback>();

        // GET: Display form and submitted products
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ProductFeedbackViewModel
            {
                //Show latest feedback by latest rating
                ProductFeedbacks = productFeedbacks.OrderByDescending(p => p.SubmittedAt).ToList(),

                LatestProductFeedback = productFeedbacks.Any() ? productFeedbacks.Max(p => p.SubmittedAt) : DateTime.MinValue
            };
            return View(model);
        }

        //POST: Accept form submission
        [HttpPost]
        public IActionResult Create(ProductFeedback productFeedback)
        {
            if (ModelState.IsValid)
            {
                //Add submission timestamp
                productFeedback.SubmittedAt = DateTime.Now;

                // Add product feedback to the in memory list
                productFeedbacks.Add(productFeedback);
            }
            var model = new ProductFeedbackViewModel
            {
                ProductFeedbacks = productFeedbacks.OrderByDescending(p => p.SubmittedAt).ToList(),
                LatestProductFeedback = productFeedbacks.Any() ? productFeedbacks.Max(p => p.SubmittedAt) :
                DateTime.MinValue
            };
            return View(model);
        }
        
    }

    // View model to combine form and list of product feedbacks
    public class ProductFeedbackViewModel
    {
        public ProductFeedback ProductFeedback { get; set; } = new ProductFeedback();

        // List of all customers
        public List<ProductFeedback> ProductFeedbacks { get; set; } = new List<ProductFeedback>();

        // Rating of the latest product feedback for highlighting
        public DateTime LatestProductFeedback { get; set; }
    }
}
