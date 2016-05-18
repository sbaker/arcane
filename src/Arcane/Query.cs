using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Arcane
{
    public class Query<T> : IQuery<T>
    {
        public Query(IQueryable<T> innerQuery)
        {
            InnerQuery = innerQuery;
        }

        public IQueryable<T> InnerQuery { get; }

        Type IQueryable.ElementType => InnerQuery.ElementType;

        Expression IQueryable.Expression => InnerQuery.Expression;

        IQueryProvider IQueryable.Provider => InnerQuery.Provider;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IQuery<T>)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return InnerQuery.GetEnumerator();
        }
    }
}