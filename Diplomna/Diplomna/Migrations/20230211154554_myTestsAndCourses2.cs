using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplomna.Migrations
{
    public partial class myTestsAndCourses2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "name",
                keyValue: "Admin",
                column: "password",
                value: "$2a$11$k/D.xrbfQeiOOd6E3myHVuirlMkFnBlBKYypK8Uo9jXUs.gokXB2u");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "name",
                keyValue: "Admin",
                column: "password",
                value: "$2a$11$ebqfDmtKWg.C0PfhAf6tfetzbl74hyzVyvJRFqgJ6ZxqPDv.H4tB.");
        }
    }
}
