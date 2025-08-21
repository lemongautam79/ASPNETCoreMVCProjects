using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCProjects.Models
{
    public class Book
    {
        // Book id is required
        [Required(ErrorMessage = "Book id is required")]
        public int BookId { get; set; }

        // Title is required
        [Required(ErrorMessage ="Book Title is required")]
        public string Title { get; set; }

        //Author Name is required
        [Required(ErrorMessage ="Author name is required")]
        public string Author { get; set; }

        //Publication Year is required
        [Required(ErrorMessage ="Publication Year is required")]
        [Range(1000,2100)]
        public int PublicationYear { get; set; }

    }
}
