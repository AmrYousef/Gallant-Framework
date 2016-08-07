using System;

namespace Framework.Core.Domain
{
    public class BaseEntity : BaseObject
    {
        public Guid Id { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}