using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BangazonBE.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrderProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.OrderProductId);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    OrderStatusId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.OrderStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    IsSeller = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    OrderStatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "OrderStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardTypeName = table.Column<string>(type: "text", nullable: false),
                    CardNumber = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.PaymentTypeId);
                    table.ForeignKey(
                        name: "FK_PaymentTypes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserPayments",
                columns: table => new
                {
                    UserPaymentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPayments", x => x.UserPaymentId);
                    table.ForeignKey(
                        name: "FK_UserPayments_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPayments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Type" },
                values: new object[,]
                {
                    { 1, "Home" },
                    { 2, "Electronics" },
                    { 3, "Grocery" },
                    { 4, "Beauty" },
                    { 5, "Clothing" }
                });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "OrderId", "ProductId" },
                values: new object[,]
                {
                    { 501, 601, 403 },
                    { 502, 602, 404 },
                    { 503, 603, 401 },
                    { 504, 604, 405 },
                    { 505, 605, 402 }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "OrderStatusId", "Status" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "In Progress" },
                    { 4, "Completed" },
                    { 5, "Shipped" },
                    { 6, "Delivered" }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "PaymentTypeId", "CardNumber", "CardTypeName", "UserId" },
                values: new object[,]
                {
                    { 301, 3526, "Visa", null },
                    { 302, 2391, "Visa", null },
                    { 303, 5364, "Giftcard", null },
                    { 304, 3518, "Discover", null },
                    { 305, 6952, "Mastercard", null },
                    { 306, 2986, "American Express", null },
                    { 307, 1628, "Mastercard", null },
                    { 308, 4352, "American Express", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Name", "ProductPrice", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 401, 2, "Classic original red and blue console in perfect untouched condition", "Nintendo Switch", 300m, 3, 103 },
                    { 402, 4, "MAC Beauty Concealer in shade 3 for ivory skin-tone", "MAC Consealer Shade 3", 12.99m, 10, 101 },
                    { 403, 5, "1985 Vintage Def Leppard tee in worn-gray with front and back decal, one of a kind", "Def Leppard Vintage Tshirt", 24.99m, 1, 101 },
                    { 404, 1, "Four Mid-Century Modern Dining Chairs In Dark Walnut Finish", "Dining Chairs", 50m, 4, 103 },
                    { 405, 1, "Golden Pothos rooted propogations in small planters. Need gone NOW", "Pothos Propagations", 3.78m, 24, 101 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "Email", "FirstName", "IsSeller", "LastName" },
                values: new object[,]
                {
                    { 101, "70 Studebaker Street", "pavel@outlook.com", "Prianka", true, "Pavel" },
                    { 102, "7589 Courtland Ave", "keutzer@gmail.com", "Abraham", false, "Keutzer" },
                    { 103, "485 Laurel St", "honestgoods@me.com", "Honest", true, "Goods" },
                    { 104, "5698 Grove Lane", "mleary@icloud.com", "Megan", false, "Leary" },
                    { 105, "10 South Harrison Dr", "gpetersen@yahoo.com", "George", false, "Petersen" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedAt", "OrderStatusId", "UserId" },
                values: new object[,]
                {
                    { 601, new DateTime(2023, 8, 28, 18, 36, 47, 391, DateTimeKind.Local).AddTicks(4340), 1, 102 },
                    { 602, new DateTime(2023, 8, 28, 18, 36, 47, 391, DateTimeKind.Local).AddTicks(4390), 2, 102 },
                    { 603, new DateTime(2023, 8, 28, 18, 36, 47, 391, DateTimeKind.Local).AddTicks(4400), 4, 104 },
                    { 604, new DateTime(2023, 8, 28, 18, 36, 47, 391, DateTimeKind.Local).AddTicks(4400), 6, 104 },
                    { 605, new DateTime(2023, 8, 28, 18, 36, 47, 391, DateTimeKind.Local).AddTicks(4400), 5, 105 }
                });

            migrationBuilder.InsertData(
                table: "UserPayments",
                columns: new[] { "UserPaymentId", "PaymentTypeId", "UserId" },
                values: new object[,]
                {
                    { 201, 302, 101 },
                    { 202, 303, 102 },
                    { 203, 306, 103 },
                    { 204, 308, 104 },
                    { 205, 304, 105 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_UserId",
                table: "PaymentTypes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPayments_PaymentTypeId",
                table: "UserPayments",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPayments_UserId",
                table: "UserPayments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserPayments");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
