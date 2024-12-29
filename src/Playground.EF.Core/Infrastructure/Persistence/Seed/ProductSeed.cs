using Playground.EF.Core.Domain.Entities.Abstracts;

namespace Playground.EF.Core.Infrastructure.Persistence.Seed
{
    public static class ProductSeed
    {
        public static IEnumerable<Product> GetInitialProducts()
        {
            return new List<Product>
            {
                new(
                    "Teclado",
                    25.99m,
                    "Teclado mecánico RGB",
                    100
                ),
                new(
                    "Mouse",
                    10.50m,
                    "Mouse óptico inalámbrico",
                    200
                ),
                new(
                    "Monitor",
                    199.99m,
                    "Monitor Full HD de 24 pulgadas",
                    50
                )
            };
        }
    }
}
