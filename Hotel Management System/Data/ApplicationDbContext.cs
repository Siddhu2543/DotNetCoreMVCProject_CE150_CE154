using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Hotel_Management_System.Models;

namespace Hotel_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Hotel_Management_System.Models.Room> Room { get; set; }
        public DbSet<Hotel_Management_System.Models.RoomType> RoomType { get; set; }
        public DbSet<Hotel_Management_System.Models.RoomUsage> RoomUsage { get; set; }
    }
}
