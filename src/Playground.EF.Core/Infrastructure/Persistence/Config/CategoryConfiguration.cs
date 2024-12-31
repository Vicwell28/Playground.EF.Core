using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Playground.EF.Core.Domain.Entities.Abstracts;

namespace Playground.EF.Core.Infrastructure.Persistence.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("TBL_CATEGORIES");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("CATEGORY_ID")
                .HasMaxLength(36)
                .IsRequired()
                .ValueGeneratedNever()
                .HasComment("Identificador único de la categoría, tipo GUID.");

            builder.Property(c => c.CategoryName)
                .HasColumnName("CATEGORY_NAME")
                .HasMaxLength(50)
                .IsRequired()
                .HasComment("Nombre de la categoría (máx 50 caracteres).");

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
        }
    }
}
