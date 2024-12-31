using Microsoft.EntityFrameworkCore;
using Playground.EF.Core.Helpers;
using Playground.EF.Core.Infrastructure.Persistence;
using System.Diagnostics;

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

                    var prdoucts = await context.Products
                        .Include(p => p.ProductCategories)
                        .ThenInclude(p => p.Category)
                        .Where(p => p.ProductCategories != null && p.ProductCategories.Any())
                        .ToListAsync();

                    ConsoleHelper.WriteJson(prdoucts, indent: true, ignoreCycles: true);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

            Console.WriteLine("=== Proceso finalizado ===");
            Console.ReadKey();
        }
    }
}
