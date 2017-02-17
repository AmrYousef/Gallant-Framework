using Framework.Core.CQRS.Core;
using Framework.Core.Securtiy;

namespace Framework.Core.CQRS
{
    public class AuthenticatedQuery : BaseAuthenticatedMessage, IQuery
    {
        public AuthenticatedQuery(FrameworkClaimsIdentity identity) : base(identity)
        {
        }
    }
}