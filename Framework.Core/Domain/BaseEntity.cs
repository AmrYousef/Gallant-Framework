using System;

namespace Framework.Core.Domain
{
    public class BaseEntity : BaseObject
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}