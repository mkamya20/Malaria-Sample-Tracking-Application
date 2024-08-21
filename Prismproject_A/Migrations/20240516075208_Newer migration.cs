using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prismproject_A.Migrations
{
    /// <inheritdoc />
    public partial class Newermigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MRCmapping",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Mrc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRCmapping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PasteErrors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    F2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    F3 = table.Column<TimeSpan>(type: "time", nullable: false),
                    F4 = table.Column<TimeSpan>(type: "time", nullable: false),
                    F5 = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasteErrors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SampleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoxRow = table.Column<byte>(type: "tinyint", nullable: false),
                    BoxColumn = table.Column<byte>(type: "tinyint", nullable: false),
                    TbldateAdded = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MRCmapping");

            migrationBuilder.DropTable(
                name: "PasteErrors");

            migrationBuilder.DropTable(
                name: "Report");
        }
    }
}
