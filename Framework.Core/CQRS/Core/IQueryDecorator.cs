namespace Framework.Core.CQRS.Core
{
    public interface IQueryDecorator<TQuery, TQueryResponse> : IQueryHandler<TQuery, TQueryResponse>
        where TQuery : IQuery
        where TQueryResponse : IQueryResponse
    {
    }
}