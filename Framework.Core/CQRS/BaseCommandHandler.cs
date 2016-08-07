using Framework.Core.CQRS.Core;

namespace Framework.Core.CQRS
{
    public abstract class BaseCommandHandler<T> : ICommandHandler<T> where T : ICommand
    {
        public abstract void Handle(T command);
    }
}