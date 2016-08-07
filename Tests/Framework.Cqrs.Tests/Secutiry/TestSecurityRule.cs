using Framework.Core.CQRS.Core;
using Framework.Core.Securtiy;

namespace Framework.Cqrs.Tests.Secutiry
{
    public class TestSecurityRule<TMessage> : ISecurityRule<TMessage> where TMessage : IMessage
    {
        public bool IsAuthorized(FrameworkClaimsIdentity currentUserIdentity)
        {
            return true;
        }
    }
}