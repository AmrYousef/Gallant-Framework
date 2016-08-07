namespace Framework.Core.CQRS.Core
{
    public interface ICommandDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
    }
}