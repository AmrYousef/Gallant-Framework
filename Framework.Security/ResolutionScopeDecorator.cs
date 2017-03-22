using Framework.Core.CQRS.Core;
using Framework.Core.DependencyContainer;

namespace Framework.Security
{
    public class ResolutionScopeDecorator<TCommand> : ICommandDecorator<TCommand> where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _commandHandler;
        private readonly IDependencyContainer _dependencyContainer;

        public ResolutionScopeDecorator(ICommandHandler<TCommand> commandHandler,
            IDependencyContainer dependencyContainer)
        {
            _commandHandler = commandHandler;
            _dependencyContainer = dependencyContainer;
        }

        public void Handle(TCommand command)
        {
            using (_dependencyContainer.BeginScope())
            {
                _commandHandler.Handle(command);
            }
        }
    }
}