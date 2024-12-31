using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Playground.EF.Core.Domain.Entities.Abstracts;

namespace Playground.EF.Core.Infrastructure.Persistence.Config
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("TBL_REVIEWS");

            builder.HasKey(r => r.Id);

            // Configuración de propiedades
            builder.Property(r => r.Id)
                   .HasColumnName("REVIEW_ID")
                   .HasMaxLength(36)
                   .IsRequired()
                   .ValueGeneratedNever()
                   .HasComment("Identificador único de la reseña, tipo GUID.");

            builder.Property(r => r.Content)
                   .HasColumnName("CONTENT")
                   .HasColumnType("nvarchar(max)")
                   .IsRequired()
                   .HasComment("Contenido de la reseña del producto.");

            builder.Property(r => r.Rating)
                   .HasColumnName("RATING")
                   .HasColumnType("int")
                   .IsRequired()
                   .HasComment("Calificación del producto (1 a 5).");

            builder.Property(r => r.CreatedAt)
                   .HasColumnName("CREATED_AT")
                   .HasColumnType("datetime2")
                   .IsRequired()
                   .HasDefaultValueSql("GETUTCDATE()")
                   .HasComment("Fecha y hora de creación de la reseña (UTC).");

            builder.Property(r => r.UpdatedAt)
                   .HasColumnName("UPDATE_AT")
                   .HasColumnType("datetime2")
                   .IsRequired(false)
                   .HasComment("Fecha y hora de actualizacion de la reseña (UTC).");

            builder.Property(r => r.ProductId)
                   .HasColumnName("PRODUCT_ID")
                   .IsRequired()
                   .HasComment("Identificador único del producto relacionado.");

            // Índices adicionales
            builder.HasIndex(r => r.ProductId).HasDatabaseName("IX_Review_ProductId");
            builder.HasIndex(r => r.Rating).HasDatabaseName("IX_Review_Rating");

            // Relaciones
            builder.HasOne(r => r.Product)
                   .WithMany(p => p.Reviews)
                   .HasForeignKey(r => r.ProductId)
                   .HasPrincipalKey(p => p.Id)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}