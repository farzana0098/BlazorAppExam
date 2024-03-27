using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorAppExam.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "StudentsMarks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalNumber = table.Column<int>(type: "int", nullable: false),
                    ObtainedNumber = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentsStudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsMarks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentsMarks_Students_StudentsStudentId",
                        column: x => x.StudentsStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Class", "Name" },
                values: new object[,]
                {
                    { 1, 6, "Bikes" },
                    { 2, 6, "Abdullah" },
                    { 3, 7, "Jannat" },
                    { 4, 7, "Bikes" },
                    { 5, 7, "Farzana" },
                    { 6, 7, "Hasib" }
                });

            migrationBuilder.InsertData(
                table: "StudentsMarks",
                columns: new[] { "ID", "EndDate", "ExamName", "ObtainedNumber", "StartDate", "StudentId", "StudentsStudentId", "TotalNumber" },
                values: new object[,]
                {
                    { 1, null, "Final", 600, null, 1, null, 800 },
                    { 2, null, "External", 600, null, 2, null, 800 },
                    { 3, null, "Evidence", 600, null, 3, null, 800 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsMarks_StudentsStudentId",
                table: "StudentsMarks",
                column: "StudentsStudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsMarks");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
