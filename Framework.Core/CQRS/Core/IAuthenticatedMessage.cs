using System;
using Framework.Core.Securtiy;

namespace Framework.Core.CQRS.Core
{
    public interface IAuthenticatedMessage : IMessage
    {
        FrameworkClaimsIdentity Identity { get; }
        Guid UserId { get; }
    }
}