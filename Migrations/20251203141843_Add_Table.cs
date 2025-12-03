using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduPortal.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseLecturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLecturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseLecturers_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseLecturers_Inf_ActivityTypes_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Inf_ActivityTypes",
                        principalColumn: "ActivityTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseLecturers_Users_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseLecturers_ActivityId",
                table: "CourseLecturers",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLecturers_CourseId",
                table: "CourseLecturers",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLecturers_LecturerId",
                table: "CourseLecturers",
                column: "LecturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseLecturers");
        }
    }
}
