﻿using Framework.Core.Data.Core;
using System.Data.Entity;
using System.Linq;

namespace Framework.EntityFramework
{
    public abstract class BaseContext : DbContext, IReadContext
    {
        public BaseContext(string connectionName) : base("Name=" + connectionName)
        {
        }

        IQueryable<T> IReadContext.Set<T>()
        {
            return this.Set<T>();
        }
    }
}