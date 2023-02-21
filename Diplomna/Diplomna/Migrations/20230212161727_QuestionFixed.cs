using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplomna.Migrations
{
    public partial class QuestionFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "question",
                table: "questions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "name",
                keyValue: "Admin",
                column: "password",
                value: "$2a$11$xc12G4l3Aeavu39Ib8M8beAfOEVdMLWq.aKObcZfojUafe4tqvpNS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "question",
                table: "questions");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "name",
                keyValue: "Admin",
                column: "password",
                value: "$2a$11$bvyp9YwNlXFcF2VnsXZZbelZ2Ww1Mo8rCDu1vpK3LHJEvfowiulOW");
        }
    }
}
