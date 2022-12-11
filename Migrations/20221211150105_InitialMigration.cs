using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });
            
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstName = table.Column<string>(type: "text", nullable: false),
                    lastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                });
            
            migrationBuilder.CreateTable(
                name: "priceChanges",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    priceChanged = table.Column<DateTime>(type: "Date", nullable: false),
                    newPrice = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_priceChanges", x => x.id);
                });
            
            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.id);
                });
            
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });
            
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });
            
            migrationBuilder.CreateTable(
                name: "purchases",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customerid = table.Column<int>(type: "integer", nullable: false),
                    purchaseDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchases", x => x.id);
                    table.ForeignKey(
                        name: "FK_purchases_clients_customerid",
                        column: x => x.customerid,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
            
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    publisherid = table.Column<int>(type: "integer", nullable: false),
                    categoryid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.id);
                    table.ForeignKey(
                        name: "FK_books_categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_books_publishers_publisherid",
                        column: x => x.publisherid,
                        principalTable: "publishers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
            
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
            
            migrationBuilder.CreateTable(
                name: "deliveries",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bookid = table.Column<int>(type: "integer", nullable: false),
                    deliveryDate = table.Column<DateTime>(type: "Date", nullable: false),
                    booksCount = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliveries", x => x.id);
                    table.ForeignKey(
                        name: "FK_deliveries_books_bookid",
                        column: x => x.bookid,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
            
            migrationBuilder.CreateTable(
                name: "purchaseItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    purchaseid = table.Column<int>(type: "integer", nullable: false),
                    bookid = table.Column<int>(type: "integer", nullable: false),
                    booksCount = table.Column<int>(type: "integer", nullable: false),
                    priceid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_purchaseItems_books_bookid",
                        column: x => x.bookid,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchaseItems_priceChanges_priceid",
                        column: x => x.priceid,
                        principalTable: "priceChanges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchaseItems_purchases_purchaseid",
                        column: x => x.purchaseid,
                        principalTable: "purchases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
            
            migrationBuilder.CreateTable(
                name: "stores",
                columns: table => new
                {
                    bookId = table.Column<int>(type: "integer", nullable: false),
                    booksCount = table.Column<int>(type: "integer", nullable: false),
                    priceid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.bookId);
                    table.ForeignKey(
                        name: "FK_stores_books_bookId",
                        column: x => x.bookId,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stores_priceChanges_priceid",
                        column: x => x.priceid,
                        principalTable: "priceChanges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
            
            migrationBuilder.CreateIndex(
                name: "IX_books_categoryid",
                table: "books",
                column: "categoryid");
            
            migrationBuilder.CreateIndex(
                name: "IX_books_publisherid",
                table: "books",
                column: "publisherid");
            
            migrationBuilder.CreateIndex(
                name: "IX_deliveries_bookid",
                table: "deliveries",
                column: "bookid");
            
            migrationBuilder.CreateIndex(
                name: "IX_purchaseItems_bookid",
                table: "purchaseItems",
                column: "bookid");
            
            migrationBuilder.CreateIndex(
                name: "IX_purchaseItems_priceid",
                table: "purchaseItems",
                column: "priceid");
            
            migrationBuilder.CreateIndex(
                name: "IX_purchaseItems_purchaseid",
                table: "purchaseItems",
                column: "purchaseid");
            
            migrationBuilder.CreateIndex(
                name: "IX_purchases_customerid",
                table: "purchases",
                column: "customerid");
            
            migrationBuilder.CreateIndex(
                name: "IX_roleUsers_usersid",
                table: "roleUsers",
                column: "usersid");
            
            migrationBuilder.CreateIndex(
                name: "IX_stores_priceid",
                table: "stores",
                column: "priceid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deliveries");
            
            migrationBuilder.DropTable(
                name: "purchaseItems");
            
            migrationBuilder.DropTable(
                name: "roleUsers");
            
            migrationBuilder.DropTable(
                name: "stores");
            
            migrationBuilder.DropTable(
                name: "purchases");
            
            migrationBuilder.DropTable(
                name: "roles");
            
            migrationBuilder.DropTable(
                name: "users");
            
            migrationBuilder.DropTable(
                name: "books");
            
            migrationBuilder.DropTable(
                name: "priceChanges");
            
            migrationBuilder.DropTable(
                name: "clients");
            
            migrationBuilder.DropTable(
                name: "categories");
            
            migrationBuilder.DropTable(
                name: "publishers");
        }
    }
}
