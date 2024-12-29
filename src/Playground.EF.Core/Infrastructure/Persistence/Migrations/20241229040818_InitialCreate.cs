using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    PRODUCT_ID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false, comment: "Identificador único del producto, tipo GUID."),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Nombre del producto (máx 50 caracteres)."),
                    PRICE = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, defaultValue: 0m, comment: "Precio unitario del producto con dos decimales de precisión."),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Descripción detallada o extensa del producto (sin límite de longitud)."),
                    STOCK_QUANTITY = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "Cantidad en inventario disponible."),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Flag para indicar si el producto está activo o no en el catálogo."),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()", comment: "Fecha y hora de creación (UTC)."),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha y hora de la última actualización (UTC)."),
                    ROW_VERSION = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Token de concurrencia para detectar actualizaciones simultáneas.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PRODUCTS", x => x.PRODUCT_ID);
                    table.CheckConstraint("CK_TBL_PRODUCTS_PRICE", "[PRICE] >= 0");
                    table.CheckConstraint("CK_TBL_PRODUCTS_STOCK", "[STOCK_QUANTITY] >= 0");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_IsActive",
                table: "TBL_PRODUCTS",
                column: "IS_ACTIVE");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Name",
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
