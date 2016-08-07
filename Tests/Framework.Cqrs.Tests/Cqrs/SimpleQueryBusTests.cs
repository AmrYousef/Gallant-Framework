using Framework.Core.CQRS.Core;
using Framework.Core.DependencyContainer;
using Framework.Cqrs.Tests.TestClasses.Contracts.Queries;
using Framework.Cqrs.Tests.TestClasses.ReponseObject;
using Framework.CQRS;
using Moq;
using NUnit.Framework;
using System;

namespace Framework.Cqrs.Tests
{
    [TestFixture]
    public class SimpleQueryBusTests
    {
        private IQueryBus _queryBus;
        private Mock<IQueryHandler<IQuery, IQueryResponse>> _queryHandlerMock;

        [SetUp]
        public void Setup()
        {
            var dependencyContainerMock = new Mock<IDependencyContainer>();
            _queryHandlerMock = new Mock<IQueryHandler<IQuery, IQueryResponse>>();
            _queryHandlerMock.Setup(h => h.Handle(It.IsAny<IQuery>())).Returns(new TestQueryResponse());
            dependencyContainerMock.Setup(d => d.ResolveQueryHandler<IQuery, IQueryResponse>()).Returns(_queryHandlerMock.Object);
            _queryBus = new SimpleQueryBus(dependencyContainerMock.Object);
        }

        [Test]
        public void QueryBusSendShallCallQueryHandleOnce()
        {
            _queryBus.Send<IQuery, IQueryResponse>(new TestQuery());
            _queryHandlerMock.Verify(h => h.Handle(It.IsAny<IQuery>()), Times.Once);
        }

        [Test]
        public void QueryBusSendShallReturnQueryResult()
        {
            var result = _queryBus.Send<IQuery, IQueryResponse>(new TestQuery());
            Assert.IsInstanceOf<IQueryResponse>(result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void QueryBusSendQueryHandlerHandleOnce()
        {
            _queryBus.Send<IQuery, IQueryResponse>(null);
            _queryHandlerMock.Verify(h => h.Handle(It.IsAny<IQuery>()), Times.Once);
        }
    }
}