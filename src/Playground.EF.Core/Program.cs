using Microsoft.EntityFrameworkCore;
using Playground.EF.Core.Infrastructure.Persistence;

namespace Playground.EF.Core
{
    internal class Program
    {
        // Cambiar la firma del método Main para que sea asíncrona
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Aplicación de Consola con EF Core ===");

            // Usar 'await using' si AppDbContext implementa IAsyncDisposable
            await using (var context = new AppDbContext())
            {
                var productId = "17D783A4-326C-4F96-B5E4-256ADD368725";

                var product = await context.Products.FirstOrDefaultAsync(p => p.Id == productId);

                if (product != null)
                {
                    product.Deactivate();

                    await context.SaveChangesAsync();
                }
            }

            Console.WriteLine("=== Proceso finalizado ===");
            Console.ReadKey();
        }
    }
}
