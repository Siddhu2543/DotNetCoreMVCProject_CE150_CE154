using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Management_System.Data.Migrations
{
    public partial class NewUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomUsage_AspNetUsers_UserId1",
                table: "RoomUsage");

            migrationBuilder.DropIndex(
                name: "IX_RoomUsage_UserId1",
                table: "RoomUsage");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "RoomUsage");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RoomUsage",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_RoomUsage_UserId",
                table: "RoomUsage",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomUsage_AspNetUsers_UserId",
                table: "RoomUsage",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomUsage_AspNetUsers_UserId",
                table: "RoomUsage");

            migrationBuilder.DropIndex(
                name: "IX_RoomUsage_UserId",
                table: "RoomUsage");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RoomUsage",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "RoomUsage",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomUsage_UserId1",
                table: "RoomUsage",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomUsage_AspNetUsers_UserId1",
                table: "RoomUsage",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
