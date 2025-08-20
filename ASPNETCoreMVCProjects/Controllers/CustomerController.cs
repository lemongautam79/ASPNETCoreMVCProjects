using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class CustomerController : Controller
    {
        // Static in memory list to store customer feedback
        private static List<Customer> customers = new List<Customer>();

        //GET: Display form and submitted customers
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CustomerViewModel
            {
                //Show latest feedback by latest rating
                Customers = customers.OrderByDescending(c => c.SubmittedAt).ToList(),
                LatestCustomerFeedback = customers.Any() ? customers.Max(c => c.SubmittedAt) : DateTime.MinValue
            };
            return View(model);
        }

        // POST: Accept form submission
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                // Add submission timestamp
                customer.SubmittedAt = DateTime.Now;

                // Add customer to the in memory list
                customers.Add(customer);
            }
            var model = new CustomerViewModel
            {

                Customers = customers.OrderByDescending(e => e.SubmittedAt).ToList(),
                LatestCustomerFeedback = customers.Any() ? customers.Max(c => c.SubmittedAt) : DateTime.MinValue
            };
            return View(model);
        }
    }

    // View Model to combine form data and list of customers feedback
    public class CustomerViewModel
    {

        public Customer Customer { get; set; } = new Customer();

        // List of all customers
        public List<Customer> Customers { get; set; } = new List<Customer>();

        // Rating of the latest customer for highlighting
        public DateTime LatestCustomerFeedback { get; set; }
    }

}
