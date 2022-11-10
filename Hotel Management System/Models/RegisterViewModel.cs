using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class RegisterViewModel
    {
        [Required, MaxLength(256)]
        public string Username { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        [Required, MaxLength(50), DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required, MaxLength(256), DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public string RememberMe { get; set; } = "false";

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
