using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCProjects.Models
{
    public class Flight
    {
        [Required(ErrorMessage = "Reservation Id is required")]
        public int ReservationId { get; set; }

        [Required(ErrorMessage = "Passenger Name is required")]
        public string PassengerName { get; set; }

        [Required(ErrorMessage = "Flight Number is required")]
        public string FlightNumber { get; set; }

        [NotPastDate]
        [DataType(DataType.Date)]
        public DateTime FlightDate { get; set; } = DateTime.Today;
    }
}


