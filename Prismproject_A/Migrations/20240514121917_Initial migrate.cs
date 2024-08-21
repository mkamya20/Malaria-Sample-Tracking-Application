using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prismproject_A.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoxLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Freezername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Compartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rack = table.Column<byte>(type: "tinyint", nullable: false),
                    Position = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FreezerDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Freezername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Compartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rack = table.Column<byte>(type: "tinyint", nullable: false),
                    Position = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreezerDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subscribed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoxLocations");

            migrationBuilder.DropTable(
                name: "FreezerDetails");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
