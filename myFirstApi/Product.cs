using System.ComponentModel.DataAnnotations;

namespace myFirstApi
{

    public class Product
    {
        [Required(ErrorMessage = "ID is required")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The 'Name' field is required.")]
        [MaxLength(100, ErrorMessage = "The maximum length of the name is 100 characters.")]
        public string Name { get; set; } = string.Empty;
        public int Number { get; set; }
        public int Quantity { get; set; }

        [MaxLength(200, ErrorMessage = "The maximum length of the description is 200 characters.")]
        public string Description { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
    }
}