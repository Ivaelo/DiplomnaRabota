using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplomna.Migrations
{
    public partial class m11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_units_courses_Courseid",
                table: "units");

            migrationBuilder.RenameColumn(
                name: "Courseid",
                table: "units",
                newName: "CoursesId");

            migrationBuilder.RenameIndex(
                name: "IX_units_Courseid",
                table: "units",
                newName: "IX_units_CoursesId");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "name",
                keyValue: "Admin",
                column: "password",
                value: "$2a$11$s7ZUNSNpKFbTg1zCYQUl4O1MJS6Z8NJeGVj0hoK1FwQq5EQlNXfMS");

            migrationBuilder.AddForeignKey(
                name: "FK_units_courses_CoursesId",
                table: "units",
                column: "CoursesId",
                principalTable: "courses",
                principalColumn: "Courseid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_units_courses_CoursesId",
                table: "units");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                table: "units",
                newName: "Courseid");

            migrationBuilder.RenameIndex(
                name: "IX_units_CoursesId",
                table: "units",
                newName: "IX_units_Courseid");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "name",
                keyValue: "Admin",
                column: "password",
                value: "$2a$11$vKNz7JtU1piimFUHQZoxP.KO9B3JCtug26eX3uARj8nzPJN/kwGwS");

            migrationBuilder.AddForeignKey(
                name: "FK_units_courses_Courseid",
                table: "units",
                column: "Courseid",
                principalTable: "courses",
                principalColumn: "Courseid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
