using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitlance.Migrations
{
    public partial class appointmentUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                schema: "Fitlance",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId1",
                schema: "Fitlance",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_UserId1",
                schema: "Fitlance",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "Fitlance",
                table: "Appointments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Fitlance",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                schema: "Fitlance",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClientId",
                schema: "Fitlance",
                table: "Appointments",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_ClientId",
                schema: "Fitlance",
                table: "Appointments",
                column: "ClientId",
                principalSchema: "Fitlance",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                schema: "Fitlance",
                table: "Appointments",
                column: "UserId",
                principalSchema: "Fitlance",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_ClientId",
                schema: "Fitlance",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                schema: "Fitlance",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ClientId",
                schema: "Fitlance",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ClientId",
                schema: "Fitlance",
                table: "Appointments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Fitlance",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                schema: "Fitlance",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId1",
                schema: "Fitlance",
                table: "Appointments",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                schema: "Fitlance",
                table: "Appointments",
                column: "UserId",
                principalSchema: "Fitlance",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId1",
                schema: "Fitlance",
                table: "Appointments",
                column: "UserId1",
                principalSchema: "Fitlance",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
