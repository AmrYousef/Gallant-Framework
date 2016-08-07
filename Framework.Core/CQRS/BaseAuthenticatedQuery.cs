using Framework.Core.CQRS.Core;
using Framework.Core.Securtiy;

namespace Framework.Core.CQRS
{
    public class BaseAuthenticatedQuery : BaseAuthenticatedMessage, IQuery
    {
        public BaseAuthenticatedQuery(FrameworkClaimsIdentity identity) : base(identity)
        {
        }
    }
}