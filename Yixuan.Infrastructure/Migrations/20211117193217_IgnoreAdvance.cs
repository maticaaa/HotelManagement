using Microsoft.EntityFrameworkCore.Migrations;

namespace Yixuan.Infrastructure.Migrations
{
    public partial class IgnoreAdvance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Advance",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Advance",
                table: "Customers",
                type: "decimal(5,2)",
                nullable: true);
        }
    }
}
