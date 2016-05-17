using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Arcane
{
    public interface IQuery<T> : IOrderedQueryable<T>
    {
    }

    public class Query<T> : IQuery<T>
    {
        public Query(IQueryable<T> innerQuery)
        {
            InnerQuery = innerQuery;
        }

        public IQueryable<T> InnerQuery { get; }

        Type IQueryable.ElementType
        {
            get
            {
                return InnerQuery.ElementType;
            }
        }

        Expression IQueryable.Expression
        {
            get
            {
                return InnerQuery.Expression;
            }
        }

        IQueryProvider IQueryable.Provider
        {
            get
            {
                return InnerQuery.Provider;
            }
        }

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
