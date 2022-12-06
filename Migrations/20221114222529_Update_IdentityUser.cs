using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitlance.Migrations
{
    public partial class Update_IdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_UserId",
                schema: "Fitlance",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Fitlance");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                schema: "Fitlance",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "Fitlance",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                schema: "Fitlance",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Fitlance",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Fitlance",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                schema: "Fitlance",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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
                name: "FK_Appointments_AspNetUsers_UserId",
                schema: "Fitlance",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Bio",
                schema: "Fitlance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                schema: "Fitlance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                schema: "Fitlance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Fitlance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Fitlance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                schema: "Fitlance",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Fitlance",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_AspNetUsers_Id",
                        column: x => x.Id,
                        principalSchema: "Fitlance",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_UserId",
                schema: "Fitlance",
                table: "Appointments",
                column: "UserId",
                principalSchema: "Fitlance",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
