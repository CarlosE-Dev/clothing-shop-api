using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "customer"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    InStock = table.Column<long>(type: "bigint", nullable: false),
                    ProductCategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Product Category_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "Product Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order Item",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<long>(type: "bigint", nullable: false, defaultValue: 1L),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order Item_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order Item_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Description", "Status" },
                values: new object[,]
                {
                    { 1L, "Payment Accepted", "Processing" },
                    { 2L, "Sucessful", "Finished" }
                });

            migrationBuilder.InsertData(
                table: "Product Category",
                columns: new[] { "Id", "CategoryType", "Description" },
                values: new object[,]
                {
                    { 1L, "Shirts", "100% Cotton" },
                    { 2L, "Accessories", "Belt" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1L, "admin", "admin", "admin" },
                    { 2L, "customer", "customer", "customer" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Brand", "Description", "InStock", "ProductCategoryId", "Size", "Value" },
                values: new object[] { 1L, "Marvel", "T-Shirt", 50L, 1L, "S", 19.99m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Brand", "Description", "InStock", "ProductCategoryId", "Size", "Value" },
                values: new object[] { 2L, "OffWhite", "Leather Belt", 5L, 2L, "M", 199.99m });

            migrationBuilder.InsertData(
                table: "Order Item",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[] { 1L, 1L, 1L, 2L });

            migrationBuilder.InsertData(
                table: "Order Item",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[] { 2L, 2L, 2L, 3L });

            migrationBuilder.CreateIndex(
                name: "IX_Order Item_OrderId",
                table: "Order Item",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order Item_ProductId",
                table: "Order Item",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryId",
                table: "Product",
                column: "ProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order Item");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Product Category");
        }
    }
}
