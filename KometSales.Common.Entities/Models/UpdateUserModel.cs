using System.ComponentModel.DataAnnotations;

namespace KometSales.Common.Entities.Models
{
    public class UpdateUserModel
    {
        [Required]
        [MaxLength(255)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        public Guid RoleId { get; set; }
    }
}
