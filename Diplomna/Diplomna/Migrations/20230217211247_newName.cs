using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplomna.Migrations
{
    public partial class newName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "name",
                keyValue: "Admin",
                column: "password",
                value: "$2a$11$YBEY04QEG9P0t1Ia.BGGnOG2I/RgsgH9.yXSl7EyuYDAmjAlHcfRS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "name",
                keyValue: "Admin",
                column: "password",
                value: "$2a$11$62t0nREMKf2Ub9Eshay2PuzIRy5eOXGI23jH4fvQxXpUXNEqz8skW");
        }
    }
}
