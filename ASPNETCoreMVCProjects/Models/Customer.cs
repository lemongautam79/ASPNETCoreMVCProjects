using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCProjects.Models
{
    public class Customer
    {
        // Customer Name is required
        [Required(ErrorMessage = "Customer Name is required")]
        public string Name { get; set; }

        // Customer Name is required
        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }

        // Email is required
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }

        // Customer rating (0 to 5 only)
        [Required(ErrorMessage = "Rating is required")]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
        public int Rating { get; set; }

        public DateTime SubmittedAt { get; set; }
    }
}
