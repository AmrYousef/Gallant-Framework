using Framework.Core.Securtiy;

namespace Framework.Core.CQRS
{
    public class AuthenticatedQuery : BaseAuthenticatedQuery
    {
        public AuthenticatedQuery(FrameworkClaimsIdentity identity) : base(identity)
        {
        }
    }
}