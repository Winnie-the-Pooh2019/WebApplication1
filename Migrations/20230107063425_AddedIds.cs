using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddedIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_deliveries_books_bookid",
                table: "deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_purchaseItems_books_bookid",
                table: "purchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_purchaseItems_priceChanges_priceid",
                table: "purchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_purchaseItems_purchases_purchaseid",
                table: "purchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_purchases_clients_customerid",
                table: "purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_stores_priceChanges_priceid",
                table: "stores");

            migrationBuilder.RenameColumn(
                name: "priceid",
                table: "stores",
                newName: "priceChangeId");

            migrationBuilder.RenameIndex(
                name: "IX_stores_priceid",
                table: "stores",
                newName: "IX_stores_priceChangeId");

            migrationBuilder.RenameColumn(
                name: "customerid",
                table: "purchases",
                newName: "customerId");

            migrationBuilder.RenameIndex(
                name: "IX_purchases_customerid",
                table: "purchases",
                newName: "IX_purchases_customerId");

            migrationBuilder.RenameColumn(
                name: "purchaseid",
                table: "purchaseItems",
                newName: "purchaseId");

            migrationBuilder.RenameColumn(
                name: "priceid",
                table: "purchaseItems",
                newName: "priceId");

            migrationBuilder.RenameColumn(
                name: "bookid",
                table: "purchaseItems",
                newName: "bookId");

            migrationBuilder.RenameIndex(
                name: "IX_purchaseItems_purchaseid",
                table: "purchaseItems",
                newName: "IX_purchaseItems_purchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_purchaseItems_priceid",
                table: "purchaseItems",
                newName: "IX_purchaseItems_priceId");

            migrationBuilder.RenameIndex(
                name: "IX_purchaseItems_bookid",
                table: "purchaseItems",
                newName: "IX_purchaseItems_bookId");

            migrationBuilder.RenameColumn(
                name: "bookid",
                table: "deliveries",
                newName: "bookId");

            migrationBuilder.RenameIndex(
                name: "IX_deliveries_bookid",
                table: "deliveries",
                newName: "IX_deliveries_bookId");

            migrationBuilder.AddForeignKey(
                name: "FK_deliveries_books_bookId",
                table: "deliveries",
                column: "bookId",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseItems_books_bookId",
                table: "purchaseItems",
                column: "bookId",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseItems_priceChanges_priceId",
                table: "purchaseItems",
                column: "priceId",
                principalTable: "priceChanges",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseItems_purchases_purchaseId",
                table: "purchaseItems",
                column: "purchaseId",
                principalTable: "purchases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchases_clients_customerId",
                table: "purchases",
                column: "customerId",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stores_priceChanges_priceChangeId",
                table: "stores",
                column: "priceChangeId",
                principalTable: "priceChanges",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_deliveries_books_bookId",
                table: "deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_purchaseItems_books_bookId",
                table: "purchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_purchaseItems_priceChanges_priceId",
                table: "purchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_purchaseItems_purchases_purchaseId",
                table: "purchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_purchases_clients_customerId",
                table: "purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_stores_priceChanges_priceChangeId",
                table: "stores");

            migrationBuilder.RenameColumn(
                name: "priceChangeId",
                table: "stores",
                newName: "priceid");

            migrationBuilder.RenameIndex(
                name: "IX_stores_priceChangeId",
                table: "stores",
                newName: "IX_stores_priceid");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "purchases",
                newName: "customerid");

            migrationBuilder.RenameIndex(
                name: "IX_purchases_customerId",
                table: "purchases",
                newName: "IX_purchases_customerid");

            migrationBuilder.RenameColumn(
                name: "purchaseId",
                table: "purchaseItems",
                newName: "purchaseid");

            migrationBuilder.RenameColumn(
                name: "priceId",
                table: "purchaseItems",
                newName: "priceid");

            migrationBuilder.RenameColumn(
                name: "bookId",
                table: "purchaseItems",
                newName: "bookid");

            migrationBuilder.RenameIndex(
                name: "IX_purchaseItems_purchaseId",
                table: "purchaseItems",
                newName: "IX_purchaseItems_purchaseid");

            migrationBuilder.RenameIndex(
                name: "IX_purchaseItems_priceId",
                table: "purchaseItems",
                newName: "IX_purchaseItems_priceid");

            migrationBuilder.RenameIndex(
                name: "IX_purchaseItems_bookId",
                table: "purchaseItems",
                newName: "IX_purchaseItems_bookid");

            migrationBuilder.RenameColumn(
                name: "bookId",
                table: "deliveries",
                newName: "bookid");

            migrationBuilder.RenameIndex(
                name: "IX_deliveries_bookId",
                table: "deliveries",
                newName: "IX_deliveries_bookid");

            migrationBuilder.AddForeignKey(
                name: "FK_deliveries_books_bookid",
                table: "deliveries",
                column: "bookid",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseItems_books_bookid",
                table: "purchaseItems",
                column: "bookid",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseItems_priceChanges_priceid",
                table: "purchaseItems",
                column: "priceid",
                principalTable: "priceChanges",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseItems_purchases_purchaseid",
                table: "purchaseItems",
                column: "purchaseid",
                principalTable: "purchases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchases_clients_customerid",
                table: "purchases",
                column: "customerid",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stores_priceChanges_priceid",
                table: "stores",
                column: "priceid",
                principalTable: "priceChanges",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
