using Framework.Core.CQRS;
using Framework.Core.Data.Core;
using System.Linq;

namespace Framework.EntityFramework
{
    public abstract class BaseReadContext : BaseContext, IReadContext
    {
        public BaseReadContext(string connectionName) : base(connectionName)
        {
        }

        public new IQueryable<T> Set<T>() where T : BaseQueryReponse
        {
            return base.Set<T>();
        }
    }
}