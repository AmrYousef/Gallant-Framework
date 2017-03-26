using System.Linq;
using Framework.Core.Data.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Framework.EntityFramework
{
    public abstract class BaseContext : DbContext, IReadContext
    {
        private readonly string _connectionString;

        protected BaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        IQueryable<T> IReadContext.Set<T>()
        {
            return Set<T>();
        }
    }
}