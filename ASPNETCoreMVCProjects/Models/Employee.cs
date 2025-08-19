using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCProjects.Models
{
    public class Employee
    {

        //ID is required
        [Required(ErrorMessage = "ID is required")]
        public int Id { get; set; }

        //Name is required
        [Required(ErrorMessage = "Employee Name is required")]
        public string Name { get; set; }

        //Department is required
        [Required(ErrorMessage = "Department Name is required")]
        public string Department { get; set; }

        //Salary is required
        [Required(ErrorMessage = "Salary is required")]
        public int Salary { get; set; }
    }
}
