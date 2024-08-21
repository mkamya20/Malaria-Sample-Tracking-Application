using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Prismproject_A.Migrations
{
    /// <inheritdoc />
    public partial class Authmigrationtwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f91c33a-a692-45aa-a429-c631259d75db", null, "sellor", null },
                    { "a3951bba-9595-49b6-9ecd-652a1150f17b", null, "admin", "sellor" },
                    { "c86a7521-7fd7-4fa0-a42c-fd10dc281701", null, "client", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f91c33a-a692-45aa-a429-c631259d75db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3951bba-9595-49b6-9ecd-652a1150f17b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c86a7521-7fd7-4fa0-a42c-fd10dc281701");
        }
    }
}
