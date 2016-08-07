using Framework.Core.Domain;
using System.Linq;

namespace Framework.Core.Data.Core
{
    public interface IWriteContext : IContext
    {
        IQueryable<T> Set<T>() where T : BaseEntity;

        void Add<T>(T newEntity) where T : BaseEntity;

        void Update<T>(T updatedEntity) where T : BaseEntity;

        void Delete<T>(T deletedEntity) where T : BaseEntity;

        void SaveChanges();
    }
}