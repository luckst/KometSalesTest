using System.ComponentModel.DataAnnotations;

namespace KometSales.Common.Entities.Models
{
    public class CreateUserModel
    {
        [Required]
        [MaxLength(255)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
        [Required]
        public Guid RoleId { get; set; }
    }
}
