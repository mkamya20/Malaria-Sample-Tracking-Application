using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Prismproject_A.Migrations
{
    /// <inheritdoc />
    public partial class OtherMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a3117247-87f5-44f4-a21c-9f999dfa5d50", null, "viewer", "viewer" },
                    { "b90db50a-9079-462c-be14-6d958508c89d", null, "admin", "admin" },
                    { "f8952710-9b5b-4eac-bf3a-621bb3ba1713", null, "client", "client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3117247-87f5-44f4-a21c-9f999dfa5d50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b90db50a-9079-462c-be14-6d958508c89d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8952710-9b5b-4eac-bf3a-621bb3ba1713");


        }
    }
}
