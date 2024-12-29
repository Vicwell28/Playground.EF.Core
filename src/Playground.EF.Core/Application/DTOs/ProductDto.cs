namespace Playground.EF.Core.Application.DTOs
{
    public class ProductDto
    {
        public ProductDto() { }

        public ProductDto(string id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}