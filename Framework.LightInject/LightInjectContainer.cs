using Framework.Core.CQRS.Core;
using Framework.Core.DependencyContainer;
using Framework.Core.Securtiy;
using Framework.LightInject.LightInject;
//using LightInject;
using System;
using System.Collections.Generic;

namespace Framework.LightInject
{
    public class LightInjectContainer : ServiceContainer, IDependencyContainer
    {
        public LightInjectContainer()
        {
            base.Register<IDependencyContainer>(d => this);
        }

        public new void Register<TService, TImplementation>() where TImplementation : class, TService where TService : class
        {
            base.Register<TService, TImplementation>();
        }

        public void RegisterCommandHandler<TCommand, TCommandHandler>() where TCommand : ICommand
            where TCommandHandler : class, ICommandHandler<TCommand>
        {
            base.Register<ICommandHandler<TCommand>, TCommandHandler>();
        }

        public void RegisterQueryHandler<TQuery, TQueryHandler, TResponse>() where TQuery : IQuery
            where TQueryHandler : class, IQueryHandler<TQuery, TResponse>
            where TResponse : IQueryResponse
        {
            base.Register<IQueryHandler<TQuery, TResponse>, TQueryHandler>();
        }

        public ICommandHandler<T> ResolveCommandHandler<T>() where T : ICommand
        {
            return base.GetInstance<ICommandHandler<T>>() as ICommandHandler<T>;
        }

        public IQueryHandler<T, TReponse> ResolveQueryHandler<T, TReponse>()
            where T : IQuery where TReponse : IQueryResponse
        {
            return base.GetInstance<IQueryHandler<T, TReponse>>() as IQueryHandler<T, TReponse>;
        }

        public T Resolve<T>() where T : class
        {
            return base.GetInstance<T>();
        }

        public new IDisposable BeginScope()
        {
            return base.BeginScope();
        }

        public void RegisterScopeLifetimeObject<TService, TImplementation>() where TImplementation : class, TService where TService : class
        {
            base.Register<TService, TImplementation>(new PerScopeLifetime());
        }

        public new void Dispose()
        {
            base.Dispose();
        }

        public object GetService(Type serviceType)
        {
            return base.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return base.GetAllInstances(serviceType);
        }

        public new void Register(Type serviceType)
        {
            base.Register(serviceType);
        }

        public void RegisterCommandDecorator<TCommand, TCommandDecorator>()
            where TCommand : ICommand
            where TCommandDecorator : ICommandDecorator<TCommand>
        {
            Decorate<ICommandHandler<TCommand>, TCommandDecorator>();
        }

        public IEnumerable<ISecurityRule<TMessage>> ResolveSecurityRules<TMessage>() where TMessage : IMessage
        {
            return base.GetAllInstances<ISecurityRule<TMessage>>();
        }

        public void RegisterSecurityRule<TMessage, TSecurityRule>()
            where TMessage : IAuthenticatedMessage
            where TSecurityRule : class, ISecurityRule<TMessage>
        {
            base.Register<ISecurityRule<TMessage>, TSecurityRule>();
        }
    }
}