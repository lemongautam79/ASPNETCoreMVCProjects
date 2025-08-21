using System.ComponentModel.DataAnnotations;

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
