using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class EmployeeController : Controller
    {

        // Static in memory list to store employee data
        private static List<Employee> employees = new List<Employee>();


        // GET: Display form and submitted employees
        [HttpGet]
        public IActionResult Create()
        {
            var model = new EmployeeViewModel
            {
                //Show employees latest first
                Employees = employees.OrderByDescending(e => e.Id).ToList(),
            };
            return View(model);
        }

        //POST: Accept form submission
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                // Add employee to the in memory list
                employees.Add(employee);
            }
            var model = new EmployeeViewModel
            {
                //Show employees latest first
                Employees = employees.OrderByDescending(e => e.Id).ToList(),
                LatestEmployeeId = employee.Id // Set the latest employee ID for highlighting
            };
            return View(model);
        }
    }


    //View Model to combine form data and list of employees
    public class EmployeeViewModel
    {
        //Form input
        public Employee Employee { get; set; } = new Employee();

        //List of all employees
        public List<Employee> Employees { get; set; } = new List<Employee>();

        //ID of the latest student for highlighting
        public int LatestEmployeeId { get; set; } = 0;
    }
}
