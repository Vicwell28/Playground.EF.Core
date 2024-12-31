using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.EF.Core.Domain.Entities.Abstracts
{
    public class Category : AuditableEntity
    {
        public string CategoryName { get; private set; } = null!;
        public ICollection<ProductCategory> ProductCategories { get; private set; } = new List<ProductCategory>();

        protected Category() { }

        public Category(string name)
        {
            CategoryName = name;
            CreatedAt = DateTime.UtcNow;
        }

        // Método de conveniencia para agregar un producto
        public void AddProduct(Product product, bool isPrimary = false)
        {
            var productCategory = new ProductCategory(product, this, isPrimary);
            ProductCategories.Add(productCategory);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
