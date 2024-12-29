namespace Playground.EF.Core.Domain.Entities.Abstracts
{
    public class Product : Entity
    {
        public string Name { get; private set; }

        public decimal Price { get; private set; }

        protected Product() { }

        public Product(string id, string name, decimal price) : base(id)
        {
            Name = name;
            Price = price;
        }

        public void Update(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdatePrice(decimal price)
        {
            Price = price;
        }
    }
}
