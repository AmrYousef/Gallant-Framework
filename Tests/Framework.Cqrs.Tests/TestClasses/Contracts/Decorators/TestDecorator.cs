using Framework.Core.CQRS.Core;

namespace Framework.Cqrs.Tests.TestClasses.Contracts.Decorators
{
    public class TestDecorator<T> : ICommandDecorator<T> where T : ICommand
    {
        private ICommandHandler<T> _handler;

        public TestDecorator(ICommandHandler<T> handler)
        {
            _handler = handler;
        }

        public void Handle(T command)
        {
            _handler.Handle(command);
        }
    }

    internal class TestDecorator<T, TR> : IQueryHandler<T, TR> where T : IQuery where TR : IQueryResponse
    {
        private IQueryHandler<T, TR> _handler;

        public TestDecorator(IQueryHandler<T, TR> handler)
        {
            _handler = handler;
        }

        public TR Handle(T query)
        {
            return _handler.Handle(query);
        }
    }
}