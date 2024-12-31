using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Playground.EF.Core.Domain.Entities.Abstracts;

namespace Playground.EF.Core.Infrastructure.Persistence.Config
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("TBL_PRODUCT_CATEGORY");

            builder.Ignore(pc => pc.Id);

            // O podemos usar una clave compuesta si no queremos un GUID: 
            builder.HasKey(pc => new { pc.ProductId, pc.CategoryId });

            builder.Property(pc => pc.ProductId)
                   .HasColumnName("PRODUCT_ID")
                   .HasMaxLength(36)
                   .IsRequired();

            builder.Property(pc => pc.CategoryId)
                   .HasColumnName("CATEGORY_ID")
                   .HasMaxLength(36)
                   .IsRequired();

            builder.Property(pc => pc.IsPrimaryCategory)
                   .HasColumnName("IS_PRIMARY_CATEGORY")
                   .HasDefaultValue(false);

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

            // Relaciones
            builder.HasOne(pc => pc.Product)
                   .WithMany(p => p.ProductCategories)
                   .HasForeignKey(pc => pc.ProductId)
                   .HasPrincipalKey(p => p.Id)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pc => pc.Category)
                   .WithMany(c => c.ProductCategories)
                   .HasForeignKey(pc => pc.CategoryId)
                   .HasPrincipalKey(c => c.Id)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
