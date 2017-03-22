using System;
using Framework.Core.CQRS;
using Framework.Core.CQRS.Core;
using Framework.Core.DependencyContainer;

namespace Framework.CQRS
{
    public class SimpleCommandBus : BaseBus, ICommandBus
    {
        public SimpleCommandBus(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
                throw new ArgumentException("Command shall not be with value null");

            CheckAuthorization<TCommand>(command);

            var commandHandler = DependencyContainer.ResolveCommandHandler<TCommand>();
            commandHandler.Handle(command);
        }
    }
}