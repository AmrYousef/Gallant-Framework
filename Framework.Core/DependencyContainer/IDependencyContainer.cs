using Framework.Core.CQRS.Core;
using Framework.Core.Securtiy;
using System;
using System.Collections.Generic;

namespace Framework.Core.DependencyContainer
{
    public interface IDependencyContainer
    {
        ICommandHandler<T> ResolveCommandHandler<T>() where T : ICommand;

        IQueryHandler<T, TReponse> ResolveQueryHandler<T, TReponse>() where T : IQuery where TReponse : IQueryResponse;

        void Register<TService, TImplementation>() where TImplementation : TService;

        T Resolve<T>();

        IEnumerable<ISecurityRule<TMessage>> ResolveSecurityRules<TMessage>() where TMessage : IMessage;

        void RegisterCommandHandler<TCommand, TCommandHandler>() where TCommand : ICommand
            where TCommandHandler : ICommandHandler<TCommand>;

        void RegisterSecurityRule<TMessage, TSecurityRule>() where TMessage : IAuthenticatedMessage
            where TSecurityRule : ISecurityRule<TMessage>;

        void RegisterCommandDecorator<TCommand, TCommandDecorator>()
            where TCommand : ICommand
            where TCommandDecorator : ICommandDecorator<TCommand>;

        //void RegisterQueryDecorator<TCommand, TCommandHandler, TCommandDecorator>()
        //    where TCommand : IQuery
        //    where TCommandHandler : ICommandHandler<TCommand>
        //    where TCommandDecorator : ICommandDecorator<TCommand>;

        void RegisterQueryHandler<TQuery, TQueryHandler, TResponse>() where TQuery : IQuery
            where TQueryHandler : IQueryHandler<TQuery, TResponse>
            where TResponse : IQueryResponse;

        void RegisterScopeLifetimeObject<TService, TImplementation>() where TImplementation : TService;

        IDisposable BeginScope();

        void Dispose();

        object GetService(Type serviceType);

        IEnumerable<object> GetServices(Type serviceType);

        void Register(Type serviceType);
    }
}