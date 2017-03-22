using System.Linq;
using Framework.Core.CQRS;

namespace Framework.Core.Data.Core
{
    public interface IReadContext : IContext
    {
        IQueryable<T> Set<T>() where T : BaseQueryReponse;
    }
}