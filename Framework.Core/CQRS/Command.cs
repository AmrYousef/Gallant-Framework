using Framework.Core.CQRS.Core;
using Framework.Core.Securtiy;

namespace Framework.Core.CQRS
{
    public abstract class Command : BaseCommand, ICommand
    {
        public Command()
        {
        }
    }
}