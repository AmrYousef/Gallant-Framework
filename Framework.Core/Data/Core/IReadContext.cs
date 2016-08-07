using Framework.Core.CQRS;
using System.Linq;

namespace Framework.Core.Data.Core
{
    public interface IReadContext : IContext
    {
        IQueryable<T> Set<T>() where T : BaseQueryReponse;
    }
}