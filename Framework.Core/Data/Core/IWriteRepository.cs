using Framework.Core.Domain;
using System;

namespace Framework.Core.Data.Core
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        void Add(T newEntity);

        void Update(T updatedEntity);

        void Delete(T deletedEntity);

        void InitRepository(IWriteContext context);

        T GetById(Guid Id);
    }
}