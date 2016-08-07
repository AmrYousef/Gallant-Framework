using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Framework.Core.Data.Core
{
    public interface IRepository<T> where T : BaseObject
    {
        IEnumerable<T> FindBy(Expression<Func<T, bool>> searchPredicate, Expression<Func<T, object>> sortPredicate, int pageNumber, int pageSize);

        IEnumerable<T> GetAll(Expression<Func<T, object>> sortPredicate, int pageNumber, int pageSize);

        //IEnumerable<T> FindBy(Expression<Func<T, bool>> searchPredicate);
        T FindSingleBy(Expression<Func<T, bool>> predicate);
    }
}