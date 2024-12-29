namespace Playground.EF.Core.Domain.Entities.Abstracts
{
    /// <summary>
    /// Representa un producto en el sistema.
    /// </summary>
    public class Product : Entity
    {
        #region Propiedades

        public string Name { get; private set; } = null!;
        public decimal Price { get; private set; }
        public string Description { get; private set; } = null!;
        public int StockQuantity { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public byte[] RowVersion { get; private set; } = null!;


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
            Name = name;
            Price = price;
            Description = description;
            StockQuantity = stockQuantity;
            MarcarComoActualizado();
        }

        public void Deactivate()
        {
            IsActive = false;
            MarcarComoActualizado();
        }

        public void Activate()
        {
            IsActive = true;
            MarcarComoActualizado();
        }

        private void MarcarComoActualizado()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        #endregion
    }
}
