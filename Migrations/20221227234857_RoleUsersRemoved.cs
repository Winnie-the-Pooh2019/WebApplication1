using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class RoleUsersRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "roleUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "id",
                table: "roles");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "users",
                newName: "rolename");

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "loginName",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "name");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_rolename",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_rolename",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "firstName",
                table: "users");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "users");

            migrationBuilder.DropColumn(
                name: "loginName",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "rolename",
                table: "users",
                newName: "name");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "roles",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "id");

            migrationBuilder.CreateTable(
                name: "roleUsers",
                columns: table => new
                {
                    rolesid = table.Column<int>(type: "integer", nullable: false),
                    usersid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roleUsers", x => new { x.rolesid, x.usersid });
                    table.ForeignKey(
                        name: "FK_roleUsers_roles_rolesid",
                        column: x => x.rolesid,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_roleUsers_users_usersid",
                        column: x => x.usersid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_roleUsers_usersid",
                table: "roleUsers",
                column: "usersid");
        }
    }
}
