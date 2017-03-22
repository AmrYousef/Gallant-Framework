using Framework.Core.DependencyContainer;
using System;
using System.Collections.Generic;
using SimpleInjector;
using Framework.Core.CQRS.Core;
using Framework.Core.Securtiy;
using SimpleInjector.Extensions.LifetimeScoping;

namespace Framework.SimpleInjector
{
    public class FrameworkDependencyContainer : Container, IDependencyContainer
    {
        public FrameworkDependencyContainer()
        {
            Func<IDependencyContainer> methodCall = () => this;
            Register(methodCall);
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

        public IDisposable BeginScope()
        {
            return this.BeginLifetimeScope();
        }

        public void RegisterScopeLifetimeObject<TService, TImplementation>()
            where TImplementation : class, TService
            where TService : class
        {
            base.Register<TService, TImplementation>(LifetimeScopeLifestyle.Scoped);
        }

        public object GetService(Type serviceType)
        {
            return base.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return base.GetAllInstances(serviceType);
        }


        public void RegisterCommandDecorator<TCommand, TCommandDecorator>()
            where TCommand : ICommand
            where TCommandDecorator : ICommandDecorator<TCommand>
        {
            //container.RegisterDecorator(typeof(ICommandHandler<>),typeof(ValidationCommandHandlerDecorator<>));
            //Decorate<ICommandHandler<TCommand>, TCommandDecorator>();
            //base.RegisterDecorator<TCommand, TCommandDecorator>();
            base.RegisterDecorator(typeof(TCommand), typeof(TCommandDecorator));
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
