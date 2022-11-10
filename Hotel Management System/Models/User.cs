using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Models
{
    public class User : IdentityUser
    {
        [NotMapped]
        public string UId { get; set; }
        [Required]
        public string Address { get; set; }

        [NotMapped]
        public string Username { get; set; }

        public User()
        {
            Username = this.UserName;
            this.UId = this.Id;
        }
    }
}
