using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Management_System.Data.Migrations
{
    public partial class NewUpdate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomType",
                table: "RoomUsage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomType",
                table: "RoomUsage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
