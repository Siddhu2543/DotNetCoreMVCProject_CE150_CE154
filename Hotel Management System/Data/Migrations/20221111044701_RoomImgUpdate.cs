using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Management_System.Data.Migrations
{
    public partial class RoomImgUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomImgUrl",
                table: "RoomType",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomImgUrl",
                table: "RoomType");
        }
    }
}
