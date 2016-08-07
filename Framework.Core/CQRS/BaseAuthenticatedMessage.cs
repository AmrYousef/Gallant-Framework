using Framework.Core.CQRS.Core;
using Framework.Core.Securtiy;
using System;

namespace Framework.Core.CQRS
{
    public abstract class BaseAuthenticatedMessage : BaseMessage, IAuthenticatedMessage
    {
        public FrameworkClaimsIdentity Identity { get; private set; }

        public Guid UserId
        {
            get
            {
                return Identity.UserId;
            }
        }

        public BaseAuthenticatedMessage(FrameworkClaimsIdentity identity)
        {
            Identity = identity;
        }
    }
}