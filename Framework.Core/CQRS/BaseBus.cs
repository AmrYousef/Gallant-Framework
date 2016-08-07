using Framework.Core.CQRS.Core;
using Framework.Core.DependencyContainer;
using System;

namespace Framework.Core.CQRS
{
    public abstract class BaseBus
    {
        protected IDependencyContainer DependencyContainer;

        public BaseBus(IDependencyContainer dependencyContainer)
        {
            DependencyContainer = dependencyContainer;
        }

        public void CheckAuthorization<TMessage>(IMessage message) where TMessage : IMessage
        {
            if (message is IAuthenticatedMessage)
            {
                var _securityRules = DependencyContainer.ResolveSecurityRules<TMessage>();

                if (_securityRules != null)
                {
                    var authenticatedCommand = message as IAuthenticatedMessage;
                    foreach (var securityRule in _securityRules)
                    {
                        if (!securityRule.IsAuthorized(authenticatedCommand.Identity))
                            throw new UnauthorizedAccessException();
                    }
                }
            }
        }
    }
}