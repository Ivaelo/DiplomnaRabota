using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplomna.Migrations
{
    public partial class TestsNameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "tests");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "tests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "name",
                keyValue: "Admin",
                column: "password",
                value: "$2a$11$bvyp9YwNlXFcF2VnsXZZbelZ2Ww1Mo8rCDu1vpK3LHJEvfowiulOW");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "tests");

            migrationBuilder.AddColumn<float>(
                name: "Score",
                table: "tests",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "name",
                keyValue: "Admin",
                column: "password",
                value: "$2a$11$6xkgb4HY49FktJA3ZihW1..RTRKVR3peGnutmb1hHDeoUK7qcBJ0S");
        }
    }
}
