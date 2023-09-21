using System.ComponentModel.DataAnnotations;

namespace KometSales.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(255)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(255)]
        public string Password { get; set; }
    }
}
