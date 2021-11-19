using Microsoft.EntityFrameworkCore.Migrations;

namespace Yixuan.Infrastructure.Migrations
{
    public partial class IgnoringRoomStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Rooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Rooms",
                type: "bit",
                nullable: true,
                defaultValue: true);
        }
    }
}
