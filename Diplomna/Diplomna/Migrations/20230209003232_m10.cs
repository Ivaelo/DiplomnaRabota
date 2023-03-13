using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Diplomna.Migrations
{
    public partial class m10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Courseid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: false),
                    CoursName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Courseid);
                    table.ForeignKey(
                        name: "FK_courses_users_UserName",
                        column: x => x.UserName,
                        principalTable: "users",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Role = table.Column<string>(type: "text", nullable: false),
                    UsersName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_roles_users_UsersName",
                        column: x => x.UsersName,
                        principalTable: "users",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "units",
                columns: table => new
                {
                    Unitid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UnitName = table.Column<string>(type: "text", nullable: false),
                    test = table.Column<string>(type: "text", nullable: false),
                    Courseid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_units", x => x.Unitid);
                    table.ForeignKey(
                        name: "FK_units_courses_Courseid",
                        column: x => x.Courseid,
                        principalTable: "courses",
                        principalColumn: "Courseid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Score = table.Column<float>(type: "real", nullable: false),
                    UnitsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tests_units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "units",
                        principalColumn: "Unitid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    VideoPath = table.Column<string>(type: "text", nullable: false),
                    UnitsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_videos_units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "units",
                        principalColumn: "Unitid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RightAnser = table.Column<string>(type: "text", nullable: false),
                    A = table.Column<string>(type: "text", nullable: false),
                    B = table.Column<string>(type: "text", nullable: false),
                    C = table.Column<string>(type: "text", nullable: false),
                    TestsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_questions_tests_TestsId",
                        column: x => x.TestsId,
                        principalTable: "tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "name", "email", "password" },
                values: new object[] { "Admin", "admin@gmail.com", "$2a$11$vKNz7JtU1piimFUHQZoxP.KO9B3JCtug26eX3uARj8nzPJN/kwGwS" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "Role", "UsersName" },
                values: new object[] { 1, "admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_courses_UserName",
                table: "courses",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_questions_TestsId",
                table: "questions",
                column: "TestsId");

            migrationBuilder.CreateIndex(
                name: "IX_roles_UsersName",
                table: "roles",
                column: "UsersName");

            migrationBuilder.CreateIndex(
                name: "IX_tests_UnitsId",
                table: "tests",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_units_Courseid",
                table: "units",
                column: "Courseid");

            migrationBuilder.CreateIndex(
                name: "IX_videos_UnitsId",
                table: "videos",
                column: "UnitsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "videos");

            migrationBuilder.DropTable(
                name: "tests");

            migrationBuilder.DropTable(
                name: "units");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
