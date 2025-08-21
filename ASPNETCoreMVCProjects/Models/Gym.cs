using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCProjects.Models
{
    public class Gym
    {

        //Id is required
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        //Name is required
        [Required(ErrorMessage = "Member Name is required")]
        public string Name { get; set; }

        //MemberShip Type is required
        [Required(ErrorMessage = "Membership type is required")]
        public string MembershipType { get; set; }


        //Join Date is required
        [NotPastDate]
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; } = DateTime.Today;

    }
}
