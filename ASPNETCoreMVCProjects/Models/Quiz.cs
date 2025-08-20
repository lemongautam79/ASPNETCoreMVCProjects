using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCProjects.Models
{
    public class Quiz
    {
        // Student Id is required
        [Required(ErrorMessage = "Student Id is required")]
        public int Id { get; set; }

        // Student Name is required
        [Required(ErrorMessage = "Student Name is required")]
        public string Name { get; set; }

        //Score is required
        [Required(ErrorMessage = "Score is required")]
        public decimal Score { get; set; }
    }
}
