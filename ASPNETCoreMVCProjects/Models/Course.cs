using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCProjects.Models
{
    public class Course
    {

        //Id is required
        [Required(ErrorMessage = "Course ID is required")]
        public int Id { get; set; }

        //Course Name is required
        [Required(ErrorMessage = "Course Name is required")]
        public string CourseName { get; set; }

        //Credits is required
        [Required(ErrorMessage = "Credits are required")]
        public int Credits { get; set; }
    }
}
