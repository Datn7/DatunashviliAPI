using Microsoft.EntityFrameworkCore.Migrations;

namespace DatunashviliAPI.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WineYears",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureUrl = table.Column<string>(nullable: false),
                    WineTypeId = table.Column<int>(nullable: false),
                    WineYearId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_WineTypes_WineTypeId",
                        column: x => x.WineTypeId,
                        principalTable: "WineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_WineYears_WineYearId",
                        column: x => x.WineYearId,
                        principalTable: "WineYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_WineTypeId",
                table: "Products",
                column: "WineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_WineYearId",
                table: "Products",
                column: "WineYearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "WineTypes");

            migrationBuilder.DropTable(
                name: "WineYears");
        }
    }
}
