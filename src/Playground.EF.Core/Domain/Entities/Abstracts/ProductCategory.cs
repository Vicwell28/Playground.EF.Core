using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.EF.Core.Domain.Entities.Abstracts
{
    public class ProductCategory : AuditableEntity
    {
        public string ProductId { get; private set; } = null!;
        public Product Product { get; private set; } = null!;

        public string CategoryId { get; private set; } = null!;
        public Category Category { get; private set; } = null!;

        // Por ejemplo, agregamos un campo extra
        public bool IsPrimaryCategory { get; private set; }

        protected ProductCategory() { }

        public ProductCategory(Product product, Category category, bool isPrimary = false)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
            Category = category ?? throw new ArgumentNullException(nameof(category));
            ProductId = product.Id;
            CategoryId = category.Id;
            IsPrimaryCategory = isPrimary;
            CreatedAt = DateTime.UtcNow;
        }

        public void MarkAsPrimary()
        {
            IsPrimaryCategory = true;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
