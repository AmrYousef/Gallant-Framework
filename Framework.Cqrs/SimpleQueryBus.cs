using System;
using Framework.Core.CQRS;
using Framework.Core.CQRS.Core;
using Framework.Core.DependencyContainer;

namespace Framework.CQRS
{
    public class SimpleQueryBus : BaseBus, IQueryBus
    {
        public SimpleQueryBus(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
        }

        public TResponse Send<TQuery, TResponse>(TQuery query) where TQuery : IQuery
            where TResponse : IQueryResponse
        {
            if (query == null)
                throw new ArgumentException("Query shall not be with value null");

            var queryHandler = DependencyContainer.ResolveQueryHandler<TQuery, TResponse>();

            return queryHandler.Handle(query);
        }
    }
}