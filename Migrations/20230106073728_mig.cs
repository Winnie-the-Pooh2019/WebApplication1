using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_categories_categoryid",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_books_publishers_publisherid",
                table: "books");

            migrationBuilder.RenameColumn(
                name: "publisherid",
                table: "books",
                newName: "publisherId");

            migrationBuilder.RenameColumn(
                name: "categoryid",
                table: "books",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_books_publisherid",
                table: "books",
                newName: "IX_books_publisherId");

            migrationBuilder.RenameIndex(
                name: "IX_books_categoryid",
                table: "books",
                newName: "IX_books_categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_categories_categoryId",
                table: "books",
                column: "categoryId",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_books_publishers_publisherId",
                table: "books",
                column: "publisherId",
                principalTable: "publishers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_categories_categoryId",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_books_publishers_publisherId",
                table: "books");

            migrationBuilder.RenameColumn(
                name: "publisherId",
                table: "books",
                newName: "publisherid");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "books",
                newName: "categoryid");

            migrationBuilder.RenameIndex(
                name: "IX_books_publisherId",
                table: "books",
                newName: "IX_books_publisherid");

            migrationBuilder.RenameIndex(
                name: "IX_books_categoryId",
                table: "books",
                newName: "IX_books_categoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_books_categories_categoryid",
                table: "books",
                column: "categoryid",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_books_publishers_publisherid",
                table: "books",
                column: "publisherid",
                principalTable: "publishers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
