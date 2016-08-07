namespace Framework.Core.CQRS.Core
{
    public interface IQueryBus : IBus
    {
        TResponse Send<TQuery, TResponse>(TQuery query)
            where TQuery : IQuery
            where TResponse : IQueryResponse;
    }
}