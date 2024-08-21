using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prismproject_A.Migrations
{
    /// <inheritdoc />
    public partial class Newmigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoxMain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SampleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Boxlocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    F4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxMain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoxSubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoxRow = table.Column<byte>(type: "tinyint", nullable: false),
                    BoxColumn = table.Column<byte>(type: "tinyint", nullable: false),
                    TbldateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PcrplateLayout = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AliquotePlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AliquotePlatePosition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxSubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocId = table.Column<byte>(type: "tinyint", nullable: false),
                    LocName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecimenTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecimenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecimenType = table.Column<byte>(type: "tinyint", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumRows = table.Column<byte>(type: "tinyint", nullable: false),
                    NumCols = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecimenTypes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoxMain");

            migrationBuilder.DropTable(
                name: "BoxSubs");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "SpecimenTypes");
        }
    }
}
