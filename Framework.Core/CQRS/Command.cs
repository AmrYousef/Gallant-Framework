﻿using Framework.Core.CQRS.Core;

namespace Framework.Core.CQRS
{
    public abstract class Command : BaseMessage, ICommand
    {
    }
}