using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplomna.Migrations
{
    public partial class untiFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test",
                table: "units");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "name",
                keyValue: "Admin",
                column: "password",
                value: "$2a$11$yB4dpcbyKNSoP0sbRUt0seHLP4ne7TL5r3.qPzCAx.pP9nW0bOGgy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "test",
                table: "units",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "name",
                keyValue: "Admin",
                column: "password",
                value: "$2a$11$YBEY04QEG9P0t1Ia.BGGnOG2I/RgsgH9.yXSl7EyuYDAmjAlHcfRS");
        }
    }
}
