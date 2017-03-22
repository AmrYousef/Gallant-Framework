using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework.Core.Data.Core;
using Framework.Core.Domain;

namespace Framework.Core.Data
{
    public class BaseRepository<T> : IRepository<T> where T : BaseObject
    {
        public IQueryable<T> Set { get; set; }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> searchPredicate,
            Expression<Func<T, object>> sortPredicate, int pageNumber, int pageSize)
        {
            var query = Set.Where(searchPredicate);

            query = query.OrderBy(sortPredicate);

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, object>> sortPredicate, int pageNumber, int pageSize)
        {
            var query = Set.OrderBy(sortPredicate);

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        //public IEnumerable<T> FindBy(Expression<Func<T, bool>> searchPredicate)
        //{
        //    return Set.Where(searchPredicate);

        //}

        public T FindSingleBy(Expression<Func<T, bool>> predicate)
        {
            return Set.FirstOrDefault(predicate);
        }
    }
}