using Framework.Core.Data.Core;
using Framework.Core.Domain;
using System;
using System.Linq;

namespace Framework.Core.Data
{
    public abstract class BaseWriteRepository<T> : BaseRepository<T>, IWriteRepository<T> where T : BaseEntity
    {
        private IWriteContext _context;

        public BaseWriteRepository()
        {
        }

        public void InitRepository(IWriteContext context)
        {
            _context = context;
            Set = context.Set<T>();
        }

        public virtual void Add(T newEntity)
        {
            _context.Add(newEntity);
        }

        public virtual void Update(T updatedEntity)
        {
            _context.Update(updatedEntity);
        }

        public virtual void Delete(T deletedEntity)
        {
            _context.Delete(deletedEntity);
        }

        public T GetById(Guid Id)
        {
            return Set.FirstOrDefault(o => o.Id == Id);
        }
    }
}