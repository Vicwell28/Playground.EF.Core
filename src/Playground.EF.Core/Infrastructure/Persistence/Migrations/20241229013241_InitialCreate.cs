using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Playground.EF.Core.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_PRODUCTS",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PRICE = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PRODUCTS", x => x.PRODUCT_ID);
                });

            migrationBuilder.InsertData(
                table: "TBL_PRODUCTS",
                columns: new[] { "PRODUCT_ID", "NAME", "PRICE" },
                values: new object[,]
                {
                    { "180435F8-D7DB-4230-8B9E-5B5298929F00", "Mouse", 10.50m },
                    { "32D8D70C-77E8-41B1-B249-73EE7A747E6A", "Teclado", 25.99m },
                    { "977C49D1-62CA-4B6E-9848-1B1A989EA8BB", "Monitor", 199.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Nombre",
                table: "TBL_PRODUCTS",
                column: "NAME");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_PRODUCTS");
        }
    }
}
