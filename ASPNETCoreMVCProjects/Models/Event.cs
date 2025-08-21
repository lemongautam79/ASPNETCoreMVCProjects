using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCProjects.Models
{
    public class Event
    {
        public int EventId { get; set; }

        // Event Name is required
        [Required(ErrorMessage ="Event Name is required")]
        public string EventName { get; set; }

        // Event Date is required
        [Required(ErrorMessage = "EventDate is required")]
        [FutureDate(ErrorMessage = "Event Date must be in the future (not today or past).")]
        public DateTime Date { get; set; }

        // Venue Name is required
        [Required(ErrorMessage = "Venue Name is required")]
        public string Venue { get; set; }

    }
}

public class FutureDateAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is DateTime date)
        {
            return date > DateTime.Today;  // strictly future
        }
        return false;
    }
}
