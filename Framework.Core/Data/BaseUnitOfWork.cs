using Framework.Core.Data.Core;
using Framework.Core.DependencyContainer;
using Framework.Core.Domain;

namespace Framework.Core.Data
{
    public abstract class BaseUnitOfWork : IUnitOfWork
    {
        private IWriteContext _context;
        private IDependencyContainer _dependencyContainer;

        public BaseUnitOfWork(IWriteContext context, IDependencyContainer dependencyContainer)
        {
            _context = context;
            _dependencyContainer = dependencyContainer;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public TWriteRepository Repository<TWriteRepository, TEntity>()
            where TWriteRepository : IWriteRepository<TEntity>
            where TEntity : BaseEntity
        {
            var repo = _dependencyContainer.Resolve<TWriteRepository>();
            repo.InitRepository(_context);
            return repo;
        }
    }
}