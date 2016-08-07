using Framework.Core.CQRS.Core;
using Framework.Core.Securtiy;

namespace Framework.Core.CQRS
{
    public abstract class BaseAuthenticatedCommand : BaseAuthenticatedMessage, ICommand
    {
        public BaseAuthenticatedCommand(FrameworkClaimsIdentity identity) : base(identity)
        {
        }
    }
}