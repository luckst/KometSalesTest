using System.ComponentModel.DataAnnotations;

namespace KometSales.Common.Entities.Models
{
    public class CustomerModel
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(255)]
        public string? Email { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        [MaxLength(255)]
        public string? Address { get; set; }
    }
}
