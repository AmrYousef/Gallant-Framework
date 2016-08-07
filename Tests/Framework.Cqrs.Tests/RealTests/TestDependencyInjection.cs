using Framework.Core.DependencyContainer;
using Framework.Core.Securtiy;
using Framework.Cqrs.Tests.Secutiry;
using Framework.Cqrs.Tests.TestClasses.Contracts.Commands;
using Framework.Cqrs.Tests.TestClasses.Contracts.Decorators;
using Framework.Cqrs.Tests.TestClasses.Services.CommandHandler;
using Framework.CQRS;
using Framework.LightInject;
using NUnit.Framework;
using System;

namespace Framework.Cqrs.Tests
{
    [TestFixture]
    public class TestDependencyInjection
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RealTestForDecorator()
        {
            IDependencyContainer container = new LightInjectContainer();

            container.RegisterCommandHandler<TestAuthenticatedCommand, TestAuthenticatedCommandHandler>();
            container.RegisterCommandDecorator<TestAuthenticatedCommand, TestDecorator<TestAuthenticatedCommand>>();

            var bus = new SimpleCommandBus(container);

            var command = new TestAuthenticatedCommand(new FrameworkClaimsIdentity(Guid.Empty));
            bus.Send(command);
        }

        [Test]
        public void RealTestForSecurityRule()
        {
            IDependencyContainer container = new LightInjectContainer();

            container.RegisterCommandHandler<TestAuthenticatedCommand, TestAuthenticatedCommandHandler>();
            container.RegisterSecurityRule<TestAuthenticatedCommand, TestSecurityRule<TestAuthenticatedCommand>>();

            var bus = new SimpleCommandBus(container);

            var command = new TestAuthenticatedCommand(new FrameworkClaimsIdentity(Guid.Empty));
            bus.Send(command);
        }
    }
}