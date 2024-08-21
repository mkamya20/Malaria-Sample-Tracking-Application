using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prismproject_A.Migrations
{
    /// <inheritdoc />
    public partial class Zumba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZumbaSamples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoxRow = table.Column<byte>(type: "tinyint", nullable: false),
                    BoxColumn = table.Column<byte>(type: "tinyint", nullable: false),
                    dateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Round = table.Column<byte>(type: "tinyint", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZumbaSamples", x => x.Id);
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZumbaSamples");

        }
    }
}
