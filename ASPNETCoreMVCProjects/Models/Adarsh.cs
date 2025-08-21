using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCProjects.Models
{
    public class Adarsh
    {
        //ID is required
        [Required(ErrorMessage="ID is required")]
        public int ID { get; set; }

        // Name is required
        [Required(ErrorMessage = "name is required")]
        public string Name { get; set; }

        // roll no is required 
        [Required(ErrorMessage = "roll no is required")]
        public int RollNo { get; set; }

        // email is required
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
