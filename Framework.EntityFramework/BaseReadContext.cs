﻿using System.Linq;
using Framework.Core.CQRS;
using Framework.Core.Data.Core;

namespace Framework.EntityFramework
{
    public abstract class BaseReadContext : BaseContext, IReadContext
    {
        protected BaseReadContext(string connectionString) : base(connectionString)
        {
        }

        public new IQueryable<T> Set<T>() where T : BaseQueryReponse
        {
            return base.Set<T>();
        }
    }
}