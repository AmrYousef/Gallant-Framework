namespace Framework.Core.CQRS.Core
{
    public interface ICommandBus : IBus
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}