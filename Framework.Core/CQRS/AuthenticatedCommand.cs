using Framework.Core.CQRS.Core;
using Framework.Core.Securtiy;

namespace Framework.Core.CQRS
{
    public class AuthenticatedCommand : BaseAuthenticatedMessage, ICommand
    {
        public AuthenticatedCommand(FrameworkClaimsIdentity identity) : base(identity)
        {
        }
    }
}