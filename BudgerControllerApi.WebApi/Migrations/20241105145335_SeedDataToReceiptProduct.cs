using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgerControllerApi.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToReceiptProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14835b33-1e00-43fa-959b-b5f7abd0e4c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae5c69ef-d75d-405a-9ba3-9be8276c45f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d85dfdef-af8e-4b1e-919d-6396e1da8291");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57b04f27-dbf5-4c24-ae7a-2ebce4ddd155", null, "Customer", "CUSTOMER" },
                    { "5dc47954-3134-4935-97ea-1a0def25c579", null, "Manager", "MANAGER" },
                    { "c128b0f0-a749-4aac-94ab-975a9ddc3c31", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "ReceiptProducts",
                columns: new[] { "Id", "ProductId", "ReceiptId" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Receipts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 17, 53, 35, 316, DateTimeKind.Local).AddTicks(4354));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57b04f27-dbf5-4c24-ae7a-2ebce4ddd155");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5dc47954-3134-4935-97ea-1a0def25c579");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c128b0f0-a749-4aac-94ab-975a9ddc3c31");

            migrationBuilder.DeleteData(
                table: "ReceiptProducts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14835b33-1e00-43fa-959b-b5f7abd0e4c8", null, "Manager", "MANAGER" },
                    { "ae5c69ef-d75d-405a-9ba3-9be8276c45f7", null, "Admin", "ADMIN" },
                    { "d85dfdef-af8e-4b1e-919d-6396e1da8291", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Receipts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 12, 15, 14, 396, DateTimeKind.Local).AddTicks(5283));
        }
    }
}
