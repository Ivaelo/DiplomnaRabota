using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Diplomna.Migrations
{
    public partial class Tables : Migration
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
                    CourseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_units", x => x.Unitid);
                    table.ForeignKey(
                        name: "FK_units_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Courseid",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "name", "email", "password" },
                values: new object[] { "Admin", "admin@gmail.com", "$2a$11$YqZWTAu6TgOq/MkkSZ55n.SA06AEPLjjYBiyjzLXFcC1E37I5tgKa" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "Role", "UsersName" },
                values: new object[] { 1, "admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_courses_UserName",
                table: "courses",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_roles_UsersName",
                table: "roles",
                column: "UsersName");

            migrationBuilder.CreateIndex(
                name: "IX_units_CourseId",
                table: "units",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_videos_UnitsId",
                table: "videos",
                column: "UnitsId");
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
