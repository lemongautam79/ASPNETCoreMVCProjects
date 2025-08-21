using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCProjects.Models
{
    public class StudentMarks
    {
        // Id is required
        public int StudentId { get; set; }

        // Student Name is required
        [Required]
        public string Name { get; set; }

        [Required]
        public string Subject { get; set; }

        [Range(0, 100, ErrorMessage = "Marks must be between 0 and 100")]
        public int Marks { get; set; }
    }
}
