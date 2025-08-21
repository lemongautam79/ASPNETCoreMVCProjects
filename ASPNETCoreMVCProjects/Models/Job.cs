using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCProjects.Models
{
    public class Job
    {
        // Application ID is required
        [Required(ErrorMessage = "Application id is required")]
        public int ApplicationId { get; set; }

        // Applicant Name is required
        [Required(ErrorMessage = "Applicant Name is required")]
        public string Name { get; set; }

        // Position is required
        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; }

        // Experience is required
        [Required(ErrorMessage = "Experience is required")]
        public int Experience { get; set; }


    }
}
