using System;
using Framework.Core.CQRS.Core;
using Framework.Core.DependencyContainer;

namespace Framework.Core.CQRS
{
    public abstract class BaseBus
    {
        protected IDependencyContainer _dependencyContainer;

        public BaseBus(IDependencyContainer dependencyContainer)
        {
            _dependencyContainer = dependencyContainer;
        }

        public void CheckAuthorization<TMessage>(IMessage message) where TMessage : IMessage
        {
            if (message is IAuthenticatedMessage)
            {
                var _securityRules = _dependencyContainer.ResolveSecurityRules<TMessage>();

                if (_securityRules != null)
                {
                    var authenticatedCommand = message as IAuthenticatedMessage;
                    foreach (var securityRule in _securityRules)
                        if (!securityRule.IsAuthorized(authenticatedCommand.Identity))
                            throw new UnauthorizedAccessException();
                }
            }
        }
    }
}