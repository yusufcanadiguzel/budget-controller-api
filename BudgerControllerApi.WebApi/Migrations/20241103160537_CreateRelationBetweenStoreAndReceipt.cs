using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgerControllerApi.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelationBetweenStoreAndReceipt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79735d2b-80ef-4fe2-a625-d2d1ef7bf3fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9499447-a657-4187-99a2-5e0f67c1da8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f183b4d9-c392-4b0c-b8d0-1c3e124eb633");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Receipts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2efdddec-d0b8-44b5-a721-782ae46301ba", null, "Customer", "CUSTOMER" },
                    { "9e4af03e-933d-4ada-aa8d-3bdc9c24dc66", null, "Admin", "ADMIN" },
                    { "cb3fda81-de94-4e23-b91d-04808b66c809", null, "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "Receipts",
                columns: new[] { "Id", "CreatedDate", "StoreId", "TotalPrice" },
                values: new object[] { 2, new DateTime(2024, 11, 3, 19, 5, 37, 426, DateTimeKind.Local).AddTicks(4631), 1, 138m });

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_StoreId",
                table: "Receipts",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Stores_StoreId",
                table: "Receipts",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Stores_StoreId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_StoreId",
                table: "Receipts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2efdddec-d0b8-44b5-a721-782ae46301ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e4af03e-933d-4ada-aa8d-3bdc9c24dc66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb3fda81-de94-4e23-b91d-04808b66c809");

            migrationBuilder.DeleteData(
                table: "Receipts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Receipts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "79735d2b-80ef-4fe2-a625-d2d1ef7bf3fe", null, "Manager", "MANAGER" },
                    { "e9499447-a657-4187-99a2-5e0f67c1da8d", null, "Admin", "ADMIN" },
                    { "f183b4d9-c392-4b0c-b8d0-1c3e124eb633", null, "Customer", "CUSTOMER" }
                });
        }
    }
}
