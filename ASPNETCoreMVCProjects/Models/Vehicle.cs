using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCProjects.Models
{
    public class Vehicle
    {

        //Id is required
        [Required(ErrorMessage = "Vehicle ID is required")]
        public int Id { get; set; }

        //Model is required
        [Required(ErrorMessage = "Vehicle Model is required")]
        public string Model { get; set; }

        //Owner Name is required
        [Required(ErrorMessage = "Owner Name is required")]
        public string OwnerName { get; set; }

        //Year is required
        [Required(ErrorMessage = "Year is required")]
        [PastOrPresentYear(ErrorMessage = "Year must be between 1886 and the current year")]
        public int Year { get; set; }
    }
}

public class PastOrPresentYearAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is int year)
        {
            int currentYear = DateTime.Now.Year;

            if (year < 1886 || year > currentYear)
            {
                return new ValidationResult($"Year must be between 1886 and {currentYear}");
            }
        }

        return ValidationResult.Success;
    }
}
