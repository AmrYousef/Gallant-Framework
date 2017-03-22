using Framework.Core.Domain;

namespace Framework.Core.Data.Core
{
    public interface IUnitOfWork
    {
        void SaveChanges();

        TWriteRepository Repository<TWriteRepository, TEntity>()
            where TWriteRepository : class,IWriteRepository<TEntity>
            where TEntity : BaseEntity;
    }
}