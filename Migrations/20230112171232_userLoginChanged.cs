using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class userLoginChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "loginName",
                table: "users",
                newName: "login");

            migrationBuilder.RenameIndex(
                name: "IX_users_loginName",
                table: "users",
                newName: "IX_users_login");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "login",
                table: "users",
                newName: "loginName");

            migrationBuilder.RenameIndex(
                name: "IX_users_login",
                table: "users",
                newName: "IX_users_loginName");
        }
    }
}
