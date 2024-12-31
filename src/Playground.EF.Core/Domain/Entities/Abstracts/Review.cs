using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.EF.Core.Domain.Entities.Abstracts
{
    public class Review : AuditableEntity
    {
        protected Review() { }

        public string Content { get; private set; } = null!;
        public int Rating { get; private set; }

        public string ProductId { get; private set; } = null!;
        public Product Product { get; private set; } = null!;
    }
}
