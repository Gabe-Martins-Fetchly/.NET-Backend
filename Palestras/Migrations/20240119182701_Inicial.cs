using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lecture.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Experience = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    DateLecture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeLecture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speakers");
        }
    }
}
