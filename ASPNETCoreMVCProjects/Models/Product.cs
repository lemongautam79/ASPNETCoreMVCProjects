using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCProjects.Models
{
    public class Product
    {

        //Id is required
        [Required(ErrorMessage ="Id is required")]
        public int Id { get; set; }

        //Name is required
        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }

        //Price is required
        [Required
(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        //Quantity is required
        [Required(ErrorMessage = "Quantity is required")]
           public int Quantity { get; set; }

    }
}
