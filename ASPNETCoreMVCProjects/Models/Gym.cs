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

public class NotPastDateAttribute : ValidationAttribute
{
    public NotPastDateAttribute()
    {
        ErrorMessage = "Join date cannot be in the past.";
    }

    public override bool IsValid(object value)
    {
        if (value is DateTime dateValue)
        {
            // Only allow today or future dates
            return dateValue.Date >= DateTime.Today;
        }
        return true; // If null, let [Required] handle it
    }
}
