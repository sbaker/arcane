using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Arcane
{
    public abstract class Query<T> : IQuery<T>
    {
        protected Query(IQueryable<T> innerQuery, IQueryContext context)
        {
            InnerQuery = innerQuery;
            Context = context;
        }

        protected IQueryable<T> InnerQuery { get; }

        public IQueryContext Context { get; set; }

        Type IQueryable.ElementType => InnerQuery.ElementType;

        Expression IQueryable.Expression => InnerQuery.Expression;

        IQueryProvider IQueryable.Provider => InnerQuery.Provider;

        public abstract void Add(T entity);

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