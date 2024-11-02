using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgerControllerApi.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9a250bc3-24bf-4019-aa6a-03f68d22e473", null, "Customer", "CUSTOMER" },
                    { "e8c2837c-f034-48f2-b2c2-ad0c57315f08", null, "Manager", "MANAGER" },
                    { "f62b97da-2c6e-4981-874e-728369c7a802", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a250bc3-24bf-4019-aa6a-03f68d22e473");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8c2837c-f034-48f2-b2c2-ad0c57315f08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f62b97da-2c6e-4981-874e-728369c7a802");
        }
    }
}
