using ASPNETCoreMVCProjects.Models;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCProjects.Models
{
    public class Hotel
    {

        //Id is required
        [Required(ErrorMessage = "Booking ID is required")]
        public int Id { get; set; }

        //Customer Name is required
        [Required(ErrorMessage = "Customer Name is required")]
        public string CustomerName { get; set; }

        //Room Number is required
        [Required(ErrorMessage = "Room Number is required")]
        public int RoomNumber { get; set; }

        // Check -in and Check-out dates are required
        [Required(ErrorMessage = "Check-in date is required")]
        [DataType(DataType.Date)]
        [BookingDateValidation]
        public DateTime CheckInDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Check-out date is required")]
        [DataType(DataType.Date)]
        [BookingDateValidation]
        public DateTime CheckOutDate { get; set; } = DateTime.Now.AddDays(1);

    }
}

public class BookingDateValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var booking = (Hotel)validationContext.ObjectInstance;

        if (booking.CheckInDate.Date < DateTime.Today)
        {
            return new ValidationResult("Check-in date cannot be in the past.");
        }

        if (booking.CheckOutDate < booking.CheckInDate)
        {
            return new ValidationResult("Check-out date cannot be earlier than check-in date.");
        }

        return ValidationResult.Success;
    }
}

