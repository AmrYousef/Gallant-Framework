using Framework.Core.CQRS.Core;

namespace Framework.Core.Securtiy
{
    public interface ISecurityRule<TMessage> where TMessage : IMessage
    {
        bool IsAuthorized(FrameworkClaimsIdentity currentUserIdentity);
    }
}