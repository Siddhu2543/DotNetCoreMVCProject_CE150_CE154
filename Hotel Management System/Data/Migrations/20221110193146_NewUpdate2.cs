using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Management_System.Data.Migrations
{
    public partial class NewUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomUsage_AspNetUsers_UserId",
                table: "RoomUsage");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RoomUsage",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomUsage_AspNetUsers_UserId",
                table: "RoomUsage",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomUsage_AspNetUsers_UserId",
                table: "RoomUsage");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RoomUsage",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_RoomUsage_AspNetUsers_UserId",
                table: "RoomUsage",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
