using Playground.EF.Core.Domain.Entities.Contracts;

namespace Playground.EF.Core.Domain.Entities.Abstracts
{
    public abstract class Entity : IEntity
    {
        public string Id { get; private set; }
        protected Entity()
        {
            Id = Guid.NewGuid().ToString().ToUpper();
        }

        protected Entity(string id)
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString().ToUpper() : id;
        }
    }
}
