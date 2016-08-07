using Framework.Core.CQRS.Core;

namespace Framework.Core.CQRS
{
    public abstract class BaseQueryHandler<TQuery, TQueryResponse> : IQueryHandler<TQuery, TQueryResponse>
        where TQuery : IQuery
        where TQueryResponse : IQueryResponse
    {
        public abstract TQueryResponse Handle(TQuery Query);
    }
}