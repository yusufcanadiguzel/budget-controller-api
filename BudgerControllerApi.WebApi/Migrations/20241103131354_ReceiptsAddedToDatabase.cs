using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgerControllerApi.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ReceiptsAddedToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27301b66-8496-4395-bbdf-bd4047ad42d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9be2bb95-ea10-4d47-ac31-f326be136dde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe688989-b707-4b7f-9e50-fb092e0c8e98");

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receipts");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27301b66-8496-4395-bbdf-bd4047ad42d6", null, "Admin", "ADMIN" },
                    { "9be2bb95-ea10-4d47-ac31-f326be136dde", null, "Manager", "MANAGER" },
                    { "fe688989-b707-4b7f-9e50-fb092e0c8e98", null, "Customer", "CUSTOMER" }
                });
        }
    }
}
