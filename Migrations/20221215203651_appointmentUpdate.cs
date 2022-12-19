using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitlance.Migrations
{
    public partial class appointmentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrainerId",
                schema: "Fitlance",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainerId",
                schema: "Fitlance",
                table: "Appointments");
        }
    }
}
