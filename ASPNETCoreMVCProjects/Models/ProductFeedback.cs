using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCProjects.Models
{
    public class ProductFeedback
    {
        // Customer Name 
        [Required(ErrorMessage = "Customer Name is required")]
        public string Name { get; set; }

        // Customer Name 
        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }

        // Comment is required
        [Required(ErrorMessage = "Message is required")]
        public string Comment { get; set; }

        // Customer rating (0 to 5 only)
        [Required(ErrorMessage = "Rating is required")]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
        public int Rating { get; set; }

        public DateTime SubmittedAt { get; set; }

    }
}
