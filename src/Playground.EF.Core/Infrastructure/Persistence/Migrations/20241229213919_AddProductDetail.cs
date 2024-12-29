using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Playground.EF.Core.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddProductDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_PRODUCT_DETAIL",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<string>(type: "nvarchar(36)", nullable: false, comment: "Identificador único del producto relacionado."),
                    MANUFACTURER = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Fabricante del producto."),
                    MODEL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Modelo del producto."),
                    WARRANTY_INFO = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Información de garantía del producto.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PRODUCT_DETAIL", x => x.PRODUCT_ID);
                    table.ForeignKey(
                        name: "FK_TBL_PRODUCT_DETAIL_TBL_PRODUCTS_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "TBL_PRODUCTS",
                        principalColumn: "PRODUCT_ID",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_PRODUCT_DETAIL");
        }
    }
}
