using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreMVCProjects.Models
{
    public class Ecommerce
    {
        //Id is required
        [Required(ErrorMessage = "Order id is required")]
        public int Id { get; set; }

        //Customer Name is required
        [Required(ErrorMessage = "Customer Name is required")]
        public string CustomerName { get; set; }

        //Product Name is required
        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }

        // Quantity is required
        [Required(ErrorMessage ="Quantity is required")]
        public int Quantity { get; set; }

        // Price is required
        [Required(ErrorMessage ="Price is required")]
        public decimal Price { get; set; }

    }
}
