using Microsoft.EntityFrameworkCore;
using Playground.EF.Core.Domain.Entities.Abstracts;
using Playground.EF.Core.Helpers;
using Playground.EF.Core.Infrastructure.Persistence;
using System.Linq.Expressions;
using System.Net.Http.Headers;

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
