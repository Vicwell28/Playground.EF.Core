using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Playground.EF.Core.Domain.Entities.Abstracts;

namespace Playground.EF.Core.Infrastructure.Persistence.Config
{
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.ToTable("TBL_PRODUCT_DETAIL");

            builder.Ignore(pd => pd.Id);

            builder.HasKey(pd => pd.ProductId);

            builder.Property(pd => pd.Manufacturer)
                .HasColumnName("MANUFACTURER")
                .HasMaxLength(100)
                .IsRequired()
                .HasComment("Fabricante del producto.");

            builder.Property(pd => pd.Model)
                .HasColumnName("MODEL")
                .HasMaxLength(100)
                .IsRequired()
                .HasComment("Modelo del producto.");

            builder.Property(pd => pd.WarrantyInfo)
                .HasColumnName("WARRANTY_INFO")
                .HasMaxLength(500)
                .IsRequired()
                .HasComment("Información de garantía del producto.");

            builder.Property(pd => pd.ProductId)
               .HasColumnName("PRODUCT_ID")
               .IsRequired()
               .HasComment("Identificador único del producto relacionado.");

            builder.HasOne(pd => pd.Product)
             .WithOne(p => p.ProductDetail)
             .HasForeignKey<ProductDetail>(pd => pd.ProductId)
             .HasPrincipalKey<Product>(p => p.Id)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
