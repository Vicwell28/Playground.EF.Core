namespace Playground.EF.Core.Domain.Entities.Abstracts
{
    /// <summary>
    /// Representa un producto en el sistema.
    /// </summary>
    public class Product : AuditableEntity
    {
        #region Propiedades

        public string Name { get; private set; } = null!;
        public decimal Price { get; private set; }
        public string Description { get; private set; } = null!;
        public int StockQuantity { get; private set; }
        public bool IsActive { get; private set; }
        public byte[] RowVersion { get; private set; } = null!;

        public ProductDetail? ProductDetail { get; private set; }
        public ICollection<Review>? Reviews { get; private set; }
        public ICollection<ProductCategory> ProductCategories { get; private set; } = new List<ProductCategory>();

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor protegido para Entity Framework.
        /// </summary>
        protected Product() { }

        /// <summary>
        /// Constructor principal para creación de un nuevo producto.
        /// </summary>
        public Product(string name, decimal price, string description, int stockQuantity)
            : base()
        {
            Name = name;
            Price = price;
            Description = description;
            StockQuantity = stockQuantity;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        #endregion

        #region Métodos de Dominio

        public void Update(string name, decimal price, string description, int stockQuantity)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("El nombre del producto es requerido.");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException("La descripcion del producto es requerido");

            if (price < 0)
                throw new ArgumentNullException("El precio del producto no puede ser negativo.");

            if (stockQuantity < 0)
                throw new ArgumentNullException("La cantidad de stock no puede ser negativa.");

            Name = name;
            Price = price;
            Description = description;
            StockQuantity = stockQuantity;
            MarkAsUpdated();
        }

        public void Deactivate()
        {
            IsActive = false;
            MarkAsUpdated();
        }

        public void Activate()
        {
            IsActive = true;
            MarkAsUpdated();
        }

        private void MarkAsUpdated()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Incrementa la cantidad de stock.
        /// </summary>
        public void IncreaseStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("La cantidad a incrementar debe ser positiva.");

            StockQuantity += quantity;
            MarkAsUpdated();
        }

        /// <summary>
        /// Decrementa la cantidad de stock.
        /// </summary>
        public void DecreaseStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("La cantidad a decrementar debe ser positiva.");

            if (StockQuantity < quantity)
                throw new ArgumentException("No hay suficiente stock para decrementar.");

            StockQuantity -= quantity;
            MarkAsUpdated();
        }

        public void AddCategory(Category category, bool isPrimary = false)
        {
            var productCategory = new ProductCategory(this, category, isPrimary);
            ProductCategories.Add(productCategory);
            MarkAsUpdated();
        }

        #endregion
    }
}
