using Framework.Core.Securtiy;
using System;

namespace Framework.Core.CQRS.Core
{
    public interface IAuthenticatedMessage : IMessage
    {
        FrameworkClaimsIdentity Identity { get; }
        Guid UserId { get; }
    }
}