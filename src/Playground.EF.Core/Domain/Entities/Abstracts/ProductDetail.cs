namespace Playground.EF.Core.Domain.Entities.Abstracts
{
    /// <summary>
    /// Representa detalles adicionales de un producto.
    /// </summary>
    public class ProductDetail : Entity
    {
        #region Propiedades

        public string Manufacturer { get; private set; } = null!;
        public string Model { get; private set; } = null!;
        public string WarrantyInfo { get; private set; } = null!;

        public string ProductId { get; private set; } = null!;
        public Product Product { get; private set; } = null!;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor protegido para Entity Framework.
        /// </summary>
        protected ProductDetail() { }

        /// <summary>
        /// Constructor principal para creación de detalles de un producto.
        /// </summary>
        public ProductDetail(string manufacturer, string model, string warrantyInfo, string productId)
            : base()
        {
            Manufacturer = manufacturer;
            Model = model;
            WarrantyInfo = warrantyInfo;
            ProductId = productId;
        }

        /// <summary>
        /// Constructor principal para creación de detalles de un producto.
        /// </summary>
        public ProductDetail(string manufacturer, string model, string warrantyInfo, Product product)
            : base()
        {
            Manufacturer = manufacturer ?? throw new ArgumentNullException(nameof(manufacturer));
            Model = model ?? throw new ArgumentNullException(nameof(model));
            WarrantyInfo = warrantyInfo ?? throw new ArgumentNullException(nameof(warrantyInfo));
            Product = product ?? throw new ArgumentNullException(nameof(product));
            ProductId = product.Id; 
        }

        #endregion

        #region Métodos de Dominio

        public void Update(string manufacturer, string model, string warrantyInfo)
        {
            if (string.IsNullOrWhiteSpace(manufacturer))
                throw new ArgumentNullException(nameof(manufacturer), "El fabricante es requerido.");

            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentNullException(nameof(model), "El modelo es requerido.");

            if (string.IsNullOrWhiteSpace(warrantyInfo))
                throw new ArgumentNullException(nameof(warrantyInfo), "La información de garantía es requerida.");

            Manufacturer = manufacturer;
            Model = model;
            WarrantyInfo = warrantyInfo;
        }

        #endregion
    }
}