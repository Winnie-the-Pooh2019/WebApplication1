using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class UsersremovedRoleClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_rolename",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_rolename",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "rolename",
                table: "users",
                newName: "role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "users",
                newName: "rolename");

            migrationBuilder.CreateIndex(
                name: "IX_users_rolename",
                table: "users",
                column: "rolename");

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_rolename",
                table: "users",
                column: "rolename",
                principalTable: "roles",
                principalColumn: "name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
