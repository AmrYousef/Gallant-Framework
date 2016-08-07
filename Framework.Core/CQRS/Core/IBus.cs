namespace Framework.Core.CQRS.Core
{
    public interface IBus
    {
        void CheckAuthorization<TMessage>(IMessage message) where TMessage : IMessage;
    }
}