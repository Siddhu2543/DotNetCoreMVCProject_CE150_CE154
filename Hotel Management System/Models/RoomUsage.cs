using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class RoomUsage
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

        public string Status { get; set; } = "stayed";
    }
}
