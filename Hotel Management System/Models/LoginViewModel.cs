using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class LoginViewModel
    {
        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public string RememberMe { get; set; } = "false";
    }
}
