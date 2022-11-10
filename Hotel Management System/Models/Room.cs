using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public int RoomNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string status { get; set; } = "free";
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
    }
}
