namespace Framework.Core.CQRS.Core
{
    public interface IQueryHandler<TQuery, TQueryResponse>
        where TQuery : IQuery
        where TQueryResponse : IQueryResponse
    {
        TQueryResponse Handle(TQuery Query);
    }
}