using Playground.EF.Core.Infrastructure.Persistence;

namespace Playground.EF.Core
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Aplicación de Consola con EF Core ===");

            // Creamos la instancia del contexto (sin DI, sin factories)
            using (var context = new AppDbContext())
            {
                // Consultamos los datos
                var productos = context.Products.ToList();
                Console.WriteLine("Productos en la base de datos:");

                foreach (var p in productos)
                {
                    Console.WriteLine($"ID: {p.Id}, Nombre: {p.Name}, Precio: {p.Price}");
                }
            }

            Console.WriteLine("=== Proceso finalizado ===");
            Console.ReadKey();
        }
    }
}
