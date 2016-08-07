using Framework.Core.Data.Core;
using Framework.Core.Domain;
using System.Data.Entity;
using System.Linq;

namespace Framework.EntityFramework
{
    public abstract class BaseWriteContext : BaseContext, IWriteContext
    {
        public BaseWriteContext(string connectionName) : base(connectionName)
        {
        }

        public new IQueryable<T> Set<T>() where T : BaseEntity
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public virtual void Add<T>(T newEntity) where T : BaseEntity
        {
            base.Set<T>().Attach(newEntity);
            base.Entry(newEntity).State = EntityState.Added;
        }

        public virtual void Update<T>(T updatedEntity) where T : BaseEntity
        {
        }

        public void Delete<T>(T deletedEntity) where T : BaseEntity
        {
            base.Entry(deletedEntity).State = EntityState.Deleted;
        }
    }
}