using Framework.Core.CQRS;
using System.Linq;

namespace Framework.Core.Data
{
    public abstract class BaseReadRepository<T> : BaseRepository<T> where T : BaseQueryReponse
    {
        public BaseReadRepository(IQueryable<T> set)
        {
            Set = set;
        }
    }
}