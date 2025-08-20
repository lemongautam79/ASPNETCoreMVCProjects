using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCProjects.Models
{
    public class Bank
    {

        //Account id is required
        [Required(ErrorMessage ="Account Id is required")]
        public int Id { get; set; }

        // Account Holder Name is required
        [Required(ErrorMessage = "Account Holder is required")]
        public string AccountHolder { get; set; }

        //Balance is required
        [Required(ErrorMessage = "Balance is required")]
        public decimal Balance { get; set; }
    }
}
