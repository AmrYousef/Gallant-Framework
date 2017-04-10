using System.Linq;
using Framework.Core.Data.Core;
using Framework.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Framework.EntityFramework
{
    public abstract class BaseWriteContext : BaseContext, IWriteContext
    {
        protected BaseWriteContext(string connectionString) : base(connectionString)
        {
        }

        public IQueryable<T> Set<T>() where T : BaseEntity
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
            Entry(newEntity).State = EntityState.Added;
        }

        public virtual void Update<T>(T updatedEntity) where T : BaseEntity
        {
        }

        public virtual void Delete<T>(T deletedEntity) where T : BaseEntity
        {
            Entry(deletedEntity).State = EntityState.Deleted;
        }
    }
}