using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TTBeregovo.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "FullName", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1985, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Smith", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Name", "Price", "SKU" },
                values: new object[,]
                {
                    { 1, "Electronics", "Laptop", 1500m, "LAP123" },
                    { 2, "Electronics", "Smartphone", 800m, "SM123" },
                    { 3, "Furniture", "Desk Chair", 200m, "FURN123" }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CustomerId", "Date", "Number", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "PURCH001", 2300m },
                    { 2, 2, new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "PURCH002", 800m }
                });

            migrationBuilder.InsertData(
                table: "PurchaseItems",
                columns: new[] { "Id", "ProductId", "PurchaseId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 3, 1, 2 },
                    { 3, 2, 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PurchaseItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PurchaseItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PurchaseItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
