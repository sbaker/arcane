using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Arcane
{
    public class ArcaneQueryable<T> : IQueryable<T>, IQueryProvider
    {
        public ArcaneQueryable(IQueryable<T> innerQuery, IQueryContext context)
        {
            InnerQuery = innerQuery;
            Context = context;
        }

        #region IQueryable implementation

        Type IQueryable.ElementType => InnerQuery.ElementType;

        Expression IQueryable.Expression => InnerQuery.Expression;

        IQueryProvider IQueryable.Provider => this;

        #endregion

        #region IQueryProvider implementation

        IQueryable IQueryProvider.CreateQuery(Expression expression)
        {
            return CreateQuery<T>(expression);
        }

        IQueryable<TElement> IQueryProvider.CreateQuery<TElement>(Expression expression)
        {
            return CreateQuery<TElement>(expression);
        }

        object IQueryProvider.Execute(Expression expression)
        {
            return InnerQuery.Provider.Execute(expression);
        }

        TResult IQueryProvider.Execute<TResult>(Expression expression)
        {
            return InnerQuery.Provider.Execute<TResult>(expression);
        }

        #endregion

        #region IEnumerable implementation

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return InnerQuery.GetEnumerator();
        }

        #endregion

        protected IQueryable<T> InnerQuery { get; }

        protected IQueryContext Context { get; }

        protected IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            Context.EvaluateExpression(expression);

            return CreateQueryCore(
                InnerQuery.Provider.CreateQuery<TElement>(expression)
            );
        }

        /// <summary>
        /// Wraps the <paramref name="innerQuery"/> in a <see cref="ArcaneQueryable{T}"/> instance of <see cref="IQueryable{T}"/>.
        /// </summary>
        /// <typeparam name="TElement">The type of element the <see cref="IQueryable{T}"/> wraps.</typeparam>
        /// <param name="innerQuery">The <see cref="IQueryable{T}"/> innerQuery to wrap.</param>
        /// <returns></returns>
        protected virtual IQueryable<TElement> CreateQueryCore<TElement>(IQueryable<TElement> innerQuery)
        {
            return new ArcaneQueryable<TElement>(innerQuery, Context);
        }
    }
}