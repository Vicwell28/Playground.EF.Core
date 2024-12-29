using Microsoft.EntityFrameworkCore;
using Playground.EF.Core.Domain.Entities.Abstracts;
using Playground.EF.Core.Helpers;
using Playground.EF.Core.Infrastructure.Persistence;

namespace Playground.EF.Core
{
    internal class Program
    {
        // Cambiar la firma del método Main para que sea asíncrona
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Aplicación de Consola con EF Core ===");

            try
            {
                // Usar 'await using' si AppDbContext implementa IAsyncDisposable
                await using (var context = new AppDbContext())
                {
                    var productId = "17D783A4-326C-4F96-B5E4-256ADD368725";

                    var product = await context.Products.FirstOrDefaultAsync(p => p.Id == productId);

                    if (product == null)
                    {
                        Console.WriteLine("No se encontró el producto.");
                        return;
                    }

                    var productDetail = new ProductDetail("Apple", "iPhone 12", "1 año de garantía", product);

                    context.ProductDetail.Add(productDetail);

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteJson(ex, indent: true, ignoreCycles: true);
                throw;
            }

            Console.WriteLine("=== Proceso finalizado ===");
            Console.ReadKey();
        }
    }
}
