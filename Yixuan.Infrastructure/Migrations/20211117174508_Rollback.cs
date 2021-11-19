using Microsoft.EntityFrameworkCore.Migrations;

namespace Yixuan.Infrastructure.Migrations
{
    public partial class Rollback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Rooms_TestRoomNo",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_TestRoomNo",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "TestRoomNo",
                table: "Services");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestRoomNo",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_TestRoomNo",
                table: "Services",
                column: "TestRoomNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Rooms_TestRoomNo",
                table: "Services",
                column: "TestRoomNo",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
