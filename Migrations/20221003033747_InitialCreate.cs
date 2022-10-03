using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TermProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MaxAttendees = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDateTime", "Location", "MaxAttendees", "Name", "StartDateTime" },
                values: new object[] { 1, "Come watch an awesome movie with us!", new DateTime(2022, 10, 22, 23, 0, 0, 0, DateTimeKind.Local), "The movie theater", 50, "Movie Night", new DateTime(2022, 10, 22, 20, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDateTime", "Location", "MaxAttendees", "Name", "StartDateTime" },
                values: new object[] { 2, "A 3-day event loaded with speakers, Q&A's, networking opportunities, and more! You won't want to miss this.", new DateTime(2022, 10, 28, 20, 0, 0, 0, DateTimeKind.Local), "Large conference hall in Big City", null, "CIT Conference", new DateTime(2022, 10, 26, 11, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
