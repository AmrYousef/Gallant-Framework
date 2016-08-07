using Framework.Core.CQRS.Core;
using Framework.Core.DependencyContainer;
using Framework.Cqrs.Tests.TestClasses.Contracts.Commands;
using Framework.CQRS;
using Moq;
using NUnit.Framework;
using System;

namespace Framework.Cqrs.Tests
{
    [TestFixture]
    public class SimpleCommandBusTests
    {
        private ICommandBus _comandBus;
        private Mock<ICommandHandler<ICommand>> _commandHandlerMock;

        [SetUp]
        public void Setup()
        {
            var dependencyContainerMock = new Mock<IDependencyContainer>();
            _commandHandlerMock = new Mock<ICommandHandler<ICommand>>();
            dependencyContainerMock.Setup(d => d.ResolveCommandHandler<ICommand>()).Returns(_commandHandlerMock.Object);
            _comandBus = new SimpleCommandBus(dependencyContainerMock.Object);
        }

        [Test]
        public void CommandBusSendCommandHandlerHandleOnce()
        {
            _comandBus.Send<ICommand>(new TestCommand());
            _commandHandlerMock.Verify(h => h.Handle(It.IsAny<ICommand>()), Times.Once);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CommandBusSendQueryHandlerHandleOnce()
        {
            _comandBus.Send<ICommand>(null);
            _commandHandlerMock.Verify(h => h.Handle(It.IsAny<ICommand>()), Times.Once);
        }
    }
}