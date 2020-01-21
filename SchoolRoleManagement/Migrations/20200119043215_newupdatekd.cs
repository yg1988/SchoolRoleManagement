using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolRoleManagement.Migrations
{
    public partial class newupdatekd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    TeacherRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: false),
                    RequireTenure = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.TeacherRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Transitions",
                columns: table => new
                {
                    RoleTransitionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discription = table.Column<string>(nullable: false),
                    FromTeacherRoleId = table.Column<int>(nullable: false),
                    ToTeacherRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transitions", x => x.RoleTransitionId);
                    table.ForeignKey(
                        name: "FK_Transitions_Roles_FromTeacherRoleId",
                        column: x => x.FromTeacherRoleId,
                        principalTable: "Roles",
                        principalColumn: "TeacherRoleId");
                    table.ForeignKey(
                        name: "FK_Transitions_Roles_ToTeacherRoleId",
                        column: x => x.ToTeacherRoleId,
                        principalTable: "Roles",
                        principalColumn: "TeacherRoleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_FromTeacherRoleId",
                table: "Transitions",
                column: "FromTeacherRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_ToTeacherRoleId",
                table: "Transitions",
                column: "ToTeacherRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transitions");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
