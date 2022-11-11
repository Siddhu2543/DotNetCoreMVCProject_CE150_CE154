using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Models
{
    public class RoomType
    {
        public int ID { get; set; }
        [Required]
        public string Type { get; set; }
        public string RoomImgUrl { get; set; }

        [NotMapped, Required, DataType(DataType.Upload)]
        public IFormFile RoomImg { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
