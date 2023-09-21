using System.ComponentModel.DataAnnotations;

namespace KometSales.Common.Entities.Models
{
    public class ProductModel
    {
        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
