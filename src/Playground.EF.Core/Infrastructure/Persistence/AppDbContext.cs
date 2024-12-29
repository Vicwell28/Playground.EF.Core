using Microsoft.EntityFrameworkCore;
using Playground.EF.Core.Domain.Entities.Abstracts;

namespace Playground.EF.Core.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        // DbSet para nuestra entidad
        public DbSet<Product> Products { get; set; }

        // Configuración directa de la cadena de conexión
        // EF Core tomará esta configuración cuando hagas migraciones
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=LENOVOBASURTO,1433;Database=EFMasterPlaygroundDb;Integrated Security=false;User ID=sa;Password=}It3#tP6l4_xQI57nRp8nH#Vm;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;Pooling=false;")
                .LogTo(Console.WriteLine, new[] {
                DbLoggerCategory.Database.Command.Name
            }, Microsoft.Extensions.Logging.LogLevel.Information).EnableSensitiveDataLogging();
        }

        // Aplicamos las configuraciones Fluent
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplyConfiguration(modelBuilder);
        }

        public static void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}