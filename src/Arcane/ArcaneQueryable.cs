using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Arcane
{
    /// <summary>
    /// The type that wraps the external <see cref="IQueryable{T} " />.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArcaneQueryable<T> : IOrderedQueryable<T>, IQueryProvider
    {
        /// <summary>
        /// Initializes an instance of the <see cref="ArcaneQueryable{T}"/>
        /// </summary>
        /// <param name="innerQuery">The <see cref="IQueryable{T}"/> this instance wraps.</param>
        /// <param name="context">The context that created this instance.</param>
        public ArcaneQueryable(IQueryable<T> innerQuery, IQueryContext context)
        {
            InnerQuery = innerQuery;
            Context = context;
        }

        #region IQueryable implementation

        /// <summary>Gets the type of the element(s) that are returned when the expression tree associated with this instance of <see cref="T:System.Linq.IQueryable" /> is executed.</summary>
        /// <returns>A <see cref="T:System.Type" /> that represents the type of the element(s) that are returned when the expression tree associated with this object is executed.</returns>
        Type IQueryable.ElementType => InnerQuery.ElementType;

        /// <summary>Gets the expression tree that is associated with the instance of <see cref="IQueryable" />.</summary>
        /// <returns>The <see cref="Expression" /> that is associated with this instance of <see cref="IQueryable" />.</returns>
        Expression IQueryable.Expression => InnerQuery.Expression;

        /// <summary>Gets the query provider that is associated with this data source.</summary>
        /// <returns>The <see cref="IQueryProvider" /> that is associated with this data source.</returns>
        IQueryProvider IQueryable.Provider => this;

        #endregion

        #region IQueryProvider implementation

        /// <summary>Constructs an <see cref="IQueryable" /> object that can evaluate the query represented by a specified expression tree.</summary>
        /// <returns>An <see cref="IQueryable" /> that can evaluate the query represented by the specified expression tree.</returns>
        /// <param name="expression">An expression tree that represents a LINQ query.</param>
        IQueryable IQueryProvider.CreateQuery(Expression expression)
        {
            return CreateQuery<T>(expression);
        }

        /// <summary>Constructs an <see cref="IQueryable{TElement}" /> object that can evaluate the query represented by a specified expression tree.</summary>
        /// <returns>An <see cref="IQueryable{TElement}" /> that can evaluate the query represented by the specified expression tree.</returns>
        /// <param name="expression">An expression tree that represents a LINQ query.</param>
        /// <typeparam name="TElement">The type of the elements of the <see cref="IQueryable{TElement}" /> that is returned.</typeparam>
        IQueryable<TElement> IQueryProvider.CreateQuery<TElement>(Expression expression)
        {
            return CreateQuery<TElement>(expression);
        }

        /// <summary>Executes the query represented by a specified expression tree.</summary>
        /// <returns>The value that results from executing the specified query.</returns>
        /// <param name="expression">An expression tree that represents a LINQ query.</param>
        object IQueryProvider.Execute(Expression expression)
        {
            return InnerQuery.Provider.Execute(expression);
        }

        /// <summary>Executes the strongly-typed query represented by a specified expression tree.</summary>
        /// <returns>The value that results from executing the specified query.</returns>
        /// <param name="expression">An expression tree that represents a LINQ query.</param>
        /// <typeparam name="TResult">The type of the value that results from executing the query.</typeparam>
        TResult IQueryProvider.Execute<TResult>(Expression expression)
        {
            return InnerQuery.Provider.Execute<TResult>(expression);
        }

        #endregion

        #region IEnumerable implementation

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="IEnumerator" /> object that can be used to iterate through the collection.</returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>A <see cref="IEnumerator{T}" /> that can be used to iterate through the collection.</returns>
        /// <filterpriority>1</filterpriority>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return InnerQuery.GetEnumerator();
        }

        #endregion

        /// <summary>
        /// The inner <see cref="IQueryable{T}"/> that this instance wraps.
        /// </summary>
        protected IQueryable<T> InnerQuery { get; }

        /// <summary>
        /// The <see cref="IQueryContext"/> that created this instance.
        /// </summary>
        protected IQueryContext Context { get; }

        /// <summary>
        /// Calls to the <seealso cref="InnerQuery"/>'s <see cref="IQueryProvider"/> 
        /// to create a new <see cref="IQueryable{T}"/> and returns a new instance wrapping the newly created query.
        /// 
        /// Also, if <see cref="IQueryContext.SuppressCompatibilityErrors"/> is false it will call to
        /// the parent context to examine the provided expression for cross-provider compatability.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns the <see cref="InnerQuery"/>.ToString() result.
        /// </summary>
        /// <returns>A <see cref="string"/></returns>
        public override string ToString()
        {
            return InnerQuery.ToString();
        }
    }
}