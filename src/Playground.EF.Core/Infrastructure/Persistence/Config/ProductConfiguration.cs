using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Playground.EF.Core.Domain.Entities.Abstracts;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Nombre de la tabla con comentario (útil en SQL Server)
        builder.ToTable("TBL_PRODUCTS");
        // Clave primaria
        builder.HasKey(p => p.Id);

        // Configuración de columnas

        // ID
        builder.Property(p => p.Id)
            .HasColumnName("PRODUCT_ID")
            .HasMaxLength(36)
            .IsRequired()
            .ValueGeneratedNever()
            .HasComment("Identificador único del producto, tipo GUID.");

        // Name
        builder.Property(p => p.Name)
            .HasColumnName("NAME")
            .HasMaxLength(50)
            .IsRequired()
            .HasComment("Nombre del producto (máx 50 caracteres).");

        // Price
        builder.Property(p => p.Price)
            .HasColumnName("PRICE")
            .HasPrecision(10, 2)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("Precio unitario del producto con dos decimales de precisión.");

        // Description
        builder.Property(p => p.Description)
            .HasColumnName("DESCRIPTION")
            .HasColumnType("nvarchar(max)")
            .HasComment("Descripción detallada o extensa del producto (sin límite de longitud).");

        // StockQuantity
        builder.Property(p => p.StockQuantity)
            .HasColumnName("STOCK_QUANTITY")
            .IsRequired()
            .HasColumnType("int")
            .HasDefaultValue(0)
            .HasComment("Cantidad en inventario disponible.");

        // IsActive
        builder.Property(p => p.IsActive)
            .HasColumnName("IS_ACTIVE")
            .HasColumnType("bit")
            .IsRequired()
            .HasDefaultValue(true)
            .HasComment("Flag para indicar si el producto está activo o no en el catálogo.");

        // CreatedAt
        builder.Property(p => p.CreatedAt)
            .HasColumnName("CREATED_AT")
            .HasColumnType("datetime2")
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()")
            .HasComment("Fecha y hora de creación (UTC).");

        // UpdatedAt
        builder.Property(p => p.UpdatedAt)
            .HasColumnName("UPDATED_AT")
            .HasColumnType("datetime2")
            .HasComment("Fecha y hora de la última actualización (UTC).");

        // RowVersion (concurrency token)
        builder.Property(p => p.RowVersion)
            .HasColumnName("ROW_VERSION")
            .IsRowVersion()
            .IsConcurrencyToken()
            .HasComment("Token de concurrencia para detectar actualizaciones simultáneas.");

        // Si quisieras, podrías hacer un Check Constraint contra stock negativo
        builder.ToTable(b => b.HasCheckConstraint("CK_TBL_PRODUCTS_PRICE", "[PRICE] >= 0"));
        builder.ToTable(b => b.HasCheckConstraint("CK_TBL_PRODUCTS_STOCK", "[STOCK_QUANTITY] >= 0"));


        // Índices adicionales
        builder.HasIndex(p => p.Name).HasDatabaseName("IX_Product_Name");
        builder.HasIndex(p => p.IsActive).HasDatabaseName("IX_Product_IsActive");
    }
}
