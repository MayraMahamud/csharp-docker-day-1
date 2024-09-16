using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    dob = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    courseid = table.Column<int>(type: "integer", nullable: false),
                    StartDateForCourse = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    averagegrade = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    coursetitle = table.Column<string>(type: "text", nullable: false),
                    coursedescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "id", "averagegrade", "courseid", "dob", "firstname", "lastname", "StartDateForCourse" },
                values: new object[] { 1, "A", 1, new DateTime(2024, 9, 16, 8, 59, 25, 643, DateTimeKind.Utc).AddTicks(2461), "Mayra", "Mahamud", new DateTime(2024, 9, 16, 8, 59, 25, 643, DateTimeKind.Utc).AddTicks(2462) });

            migrationBuilder.InsertData(
                table: "course",
                columns: new[] { "id", "coursedescription", "coursetitle" },
                values: new object[] { 1, "Easy Course", "English" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "course");
        }
    }
}
