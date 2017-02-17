using Framework.Core.CQRS;
using Framework.Core.Securtiy;

namespace Framework.Cqrs.Tests.TestClasses.Contracts.Commands
{
    public class TestAuthenticatedCommand : Command
    {
        public TestAuthenticatedCommand(FrameworkClaimsIdentity identity) : base(identity)
        {
        }
    }
}