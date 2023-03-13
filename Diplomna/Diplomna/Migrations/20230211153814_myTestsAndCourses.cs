using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Diplomna.Migrations
{
    public partial class myTestsAndCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    coursId = table.Column<int>(type: "integer", nullable: false),
                    progres = table.Column<float>(type: "real", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyCourses_users_UserName",
                        column: x => x.UserName,
                        principalTable: "users",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Score = table.Column<float>(type: "real", nullable: false),
                    coursId = table.Column<int>(type: "integer", nullable: false),
                    TestId = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyTests_users_UserName",
                        column: x => x.UserName,
                        principalTable: "users",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "name",
                keyValue: "Admin",
                column: "password",
                value: "$2a$11$ebqfDmtKWg.C0PfhAf6tfetzbl74hyzVyvJRFqgJ6ZxqPDv.H4tB.");

            migrationBuilder.CreateIndex(
                name: "IX_MyCourses_UserName",
                table: "MyCourses",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_MyTests_UserName",
                table: "MyTests",
                column: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyCourses");

            migrationBuilder.DropTable(
                name: "MyTests");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "name",
                keyValue: "Admin",
                column: "password",
                value: "$2a$11$s7ZUNSNpKFbTg1zCYQUl4O1MJS6Z8NJeGVj0hoK1FwQq5EQlNXfMS");
        }
    }
}
