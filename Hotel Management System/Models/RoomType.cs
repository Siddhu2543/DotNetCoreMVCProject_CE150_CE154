using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class RoomType
    {
        public int ID { get; set; }
        [Required]
        public string Type { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
