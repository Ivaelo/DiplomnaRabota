using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Diplomna.Migrations
{
    public partial class DBContext : Migration
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
                    Courseid = table.Column<string>(type: "text", nullable: false),
                    CoursName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Usersname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Courseid);
                    table.ForeignKey(
                        name: "FK_courses_users_Usersname",
                        column: x => x.Usersname,
                        principalTable: "users",
                        principalColumn: "name");
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
                    Courseid = table.Column<string>(type: "text", nullable: false),
                    CoursesCourseid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_units", x => x.Unitid);
                    table.ForeignKey(
                        name: "FK_units_courses_CoursesCourseid",
                        column: x => x.CoursesCourseid,
                        principalTable: "courses",
                        principalColumn: "Courseid");
                });

            migrationBuilder.CreateTable(
                name: "videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    VideosCount = table.Column<int>(type: "integer", nullable: false),
                    VideoPath = table.Column<string>(type: "text", nullable: false),
                    Unitid = table.Column<int>(type: "integer", nullable: false),
                    UnitsUnitid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_videos_units_UnitsUnitid",
                        column: x => x.UnitsUnitid,
                        principalTable: "units",
                        principalColumn: "Unitid");
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "name", "email", "password" },
                values: new object[] { "Admin", "admin@gmail.com", "$2a$11$GJTvjkBMgl1rk0twirjATeHBfvbwRHoiIdvgIxpqZoJnxKC07wn5K" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "Role", "UsersName" },
                values: new object[] { 1, "admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_courses_Usersname",
                table: "courses",
                column: "Usersname");

            migrationBuilder.CreateIndex(
                name: "IX_roles_UsersName",
                table: "roles",
                column: "UsersName");

            migrationBuilder.CreateIndex(
                name: "IX_units_CoursesCourseid",
                table: "units",
                column: "CoursesCourseid");

            migrationBuilder.CreateIndex(
                name: "IX_videos_UnitsUnitid",
                table: "videos",
                column: "UnitsUnitid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "videos");

            migrationBuilder.DropTable(
                name: "units");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
