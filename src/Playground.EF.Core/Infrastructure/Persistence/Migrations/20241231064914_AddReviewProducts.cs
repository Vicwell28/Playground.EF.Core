using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Playground.EF.Core.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddReviewProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_REVIEWS",
                columns: table => new
                {
                    REVIEW_ID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false, comment: "Identificador único de la reseña, tipo GUID."),
                    CONTENT = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Contenido de la reseña del producto."),
                    RATING = table.Column<int>(type: "int", nullable: false, comment: "Calificación del producto (1 a 5)."),
                    PRODUCT_ID = table.Column<string>(type: "nvarchar(36)", nullable: false, comment: "Identificador único del producto relacionado."),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()", comment: "Fecha y hora de creación de la reseña (UTC)."),
                    UPDATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha y hora de actualizacion de la reseña (UTC).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_REVIEWS", x => x.REVIEW_ID);
                    table.ForeignKey(
                        name: "FK_TBL_REVIEWS_TBL_PRODUCTS_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "TBL_PRODUCTS",
                        principalColumn: "PRODUCT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProductId",
                table: "TBL_REVIEWS",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Rating",
                table: "TBL_REVIEWS",
                column: "RATING");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_REVIEWS");
        }
    }
}
