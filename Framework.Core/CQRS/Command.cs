using Framework.Core.CQRS.Core;
using Framework.Core.Securtiy;

namespace Framework.Core.CQRS
{
    public abstract class Command : BaseAuthenticatedMessage, ICommand
    {
        public Command(FrameworkClaimsIdentity identity) : base(identity)
        {
        }
    }
}