using System;
using Framework.Core.CQRS.Core;
using Framework.Core.Securtiy;

namespace Framework.Core.CQRS
{
    public abstract class BaseAuthenticatedMessage : BaseMessage, IAuthenticatedMessage
    {
        public BaseAuthenticatedMessage(FrameworkClaimsIdentity identity)
        {
            Identity = identity;
        }

        public FrameworkClaimsIdentity Identity { get; }

        public Guid UserId
        {
            get { return Identity.UserId; }
        }
    }
}