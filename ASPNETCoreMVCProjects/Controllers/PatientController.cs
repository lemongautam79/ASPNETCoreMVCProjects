using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class PatientController : Controller
    {
        // Static in-memory list to store patients
        private static List<Patient> patients = new List<Patient>();

        // GET: Display form and submitted patients
        [HttpGet]
        public IActionResult Create()
        {
            var model = new PatientViewModel
            {
                // Show latest patients first
                Patients = patients.OrderByDescending(p => p.Id).ToList()
            };
            return View(model);
        }

        // POST: Accept form submission
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                // Add patient to in-memory list
                patients.Add(patient);
            }

            var model = new PatientViewModel
            {
                Patients = patients.OrderByDescending(p => p.Id).ToList(),
                LatestPatientId = patient.Id // Highlight latest
            };

            return View(model);
        }
    }

    // ViewModel for form + list
    public class PatientViewModel
    {
        public Patient Patient { get; set; } = new Patient();

        public List<Patient> Patients { get; set; } = new List<Patient>();

        public int LatestPatientId { get; set; } = 0;
    }
}
