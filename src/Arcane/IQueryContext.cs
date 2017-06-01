using System;
using System.Linq;
using System.Linq.Expressions;
using Arcane.Data;

namespace Arcane
{
    /// <summary>
    /// Provides an interface for an abstraction around access to <see cref="IQueryable{T}" /> data entity classes.
    /// </summary>
    public interface IQueryContext : IDataStoreFactory, IDisposable
    {
        /// <summary>
        /// When set to true, will suppress cross provider compatable issues. (Note: this is not yet implemented)
        /// </summary>
        bool SuppressCompatibilityErrors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IServiceProvider Provider { get; }

        /// <summary>
        /// 
        /// </summary>
        IDataStoreFactory StoreFactory { get; }

        /// <summary>
        /// When implemented in a derived class, creates a query for the given <typeparamref name="T"/> model representing a table or collection.
        /// </summary>
        /// <typeparam name="T">The type representing the table or collection.</typeparam>
        /// <param name="name">Optional, parameter is only used in some implementations of the <see cref="IQueryContext"/></param>
        /// <returns></returns>
        IQuery<T> Query<T>(string name = null) where T : class, new();

        /// <summary>
        /// If <see cref="SuppressCompatibilityErrors"/> is false, will evaluate the current expression for common cross provider issues.
        /// </summary>
        /// <param name="expression">The expression to evaluate.</param>
        void EvaluateExpression(Expression expression);
    }

    /// <summary>
    /// Provides an interface for an abstraction around access to <see cref="IQueryable{T}" /> data entity classes.
    /// </summary>
    public interface IQueryContext<in TContext> : IQueryContext
    {
    }
}
