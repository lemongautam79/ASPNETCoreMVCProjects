using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCProjects.Models
{
    public class Movie
    {

        //Id is required
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        //Name is required
        [Required(ErrorMessage = "Movie name is required")]
        public string MovieName { get; set; }

        //Seat Number is required
        [Required(ErrorMessage = "Seat Number is required")]
        public int SeatNumber { get; set; }

        // Price is required
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

    }
}
