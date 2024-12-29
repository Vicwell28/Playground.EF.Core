using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Playground.EF.Core.Domain.Entities.Abstracts;

namespace Playground.EF.Core.Infrastructure.Persistence.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Nombre de la tabla
            builder.ToTable("TBL_PRODUCTS");

            // Clave primaria
            builder.HasKey(p => p.Id);

            // Configuración de columnas
            builder.Property(p => p.Id)
                .HasColumnName("PRODUCT_ID")
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("NAME")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnName("PRICE")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            // Si quisieras índices:
            builder.HasIndex(p => p.Name).HasDatabaseName("IX_Producto_Nombre");

            builder.HasData(
                new Product(id: "32D8D70C-77E8-41B1-B249-73EE7A747E6A", name: "Teclado", price: 25.99m),
                new Product(id: "180435F8-D7DB-4230-8B9E-5B5298929F00", name: "Mouse", price: 10.50m),
                new Product(id: "977C49D1-62CA-4B6E-9848-1B1A989EA8BB", name: "Monitor", price: 199.99m)
            );
        }
    }
}
