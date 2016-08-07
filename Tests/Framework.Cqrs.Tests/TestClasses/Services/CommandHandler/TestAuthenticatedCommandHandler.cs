using Framework.Core.CQRS.Core;
using Framework.Cqrs.Tests.TestClasses.Contracts.Commands;

namespace Framework.Cqrs.Tests.TestClasses.Services.CommandHandler
{
    public class TestAuthenticatedCommandHandler : ICommandHandler<TestAuthenticatedCommand>
    {
        public void Handle(TestAuthenticatedCommand command)
        {
        }
    }
}