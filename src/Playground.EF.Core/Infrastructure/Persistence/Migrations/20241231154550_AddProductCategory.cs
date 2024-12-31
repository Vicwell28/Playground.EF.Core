using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Playground.EF.Core.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddProductCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_CATEGORIES",
                columns: table => new
                {
                    CATEGORY_ID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false, comment: "Identificador único de la categoría, tipo GUID."),
                    CATEGORY_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Nombre de la categoría (máx 50 caracteres)."),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()", comment: "Fecha y hora de creación (UTC)."),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha y hora de la última actualización (UTC).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_CATEGORIES", x => x.CATEGORY_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PRODUCT_CATEGORY",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CATEGORY_ID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    IS_PRIMARY_CATEGORY = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()", comment: "Fecha y hora de creación (UTC)."),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha y hora de la última actualización (UTC).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PRODUCT_CATEGORY", x => new { x.PRODUCT_ID, x.CATEGORY_ID });
                    table.ForeignKey(
                        name: "FK_TBL_PRODUCT_CATEGORY_TBL_CATEGORIES_CATEGORY_ID",
                        column: x => x.CATEGORY_ID,
                        principalTable: "TBL_CATEGORIES",
                        principalColumn: "CATEGORY_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_PRODUCT_CATEGORY_TBL_PRODUCTS_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "TBL_PRODUCTS",
                        principalColumn: "PRODUCT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PRODUCT_CATEGORY_CATEGORY_ID",
                table: "TBL_PRODUCT_CATEGORY",
                column: "CATEGORY_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_PRODUCT_CATEGORY");

            migrationBuilder.DropTable(
                name: "TBL_CATEGORIES");
        }
    }
}
