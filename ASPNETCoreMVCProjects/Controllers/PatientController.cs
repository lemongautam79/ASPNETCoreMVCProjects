using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class PatientController : Controller
    {
        // Static in memory list to store patient data
        private static List<Patient> patients = new List<Patient>();


        // GET: Display form and submitted patients
        [HttpGet]
        public IActionResult Create()
        {
            var model = new PatientViewModel
            {
                //Show patients latest first
                Patients = patients.OrderByDescending(e => e.Id).ToList(),
            };
            return View(model);
        }

        //POST: Accept form submission
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                // Add patient to the in memory list
                patients.Add(patient);
            }
            var model = new PatientViewModel
            {
                //Show patients latest first
                Patients = patients.OrderByDescending(e => e.Id).ToList(),
                LatestPatientId = patient.Id // Set the latest patient ID for highlighting
            };
            return View(model);
        }
    }

    public class PatientViewModel
    {
        public Patient Patient { get; set; } = new Patient();

        //List of all patients
        public List<Patient> Patients { get; set; } = new List<Patient>();

        //ID of the latest student for highlighting
        public int LatestPatientId { get; set; } = 0;
    }
}
