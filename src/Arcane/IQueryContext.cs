using System;
using System.Linq.Expressions;

namespace Arcane
{
    /// <summary>
    /// Provides an interface for an abstraction around access to <see cref="IQueryable{T}" /> data entity classes.
    /// </summary>
    public interface IQueryContext : IDisposable
    {
        /// <summary>
        /// When set to true, will suppress cross provider compatable issues. (Note: this is not yet implemented)
        /// </summary>
        bool SuppressCompatabilityErrors { get; set; }

        /// <summary>
        /// When implemented in a derived class, creates a query for the given <typeparamref name="T"/> model representing a table or collection.
        /// </summary>
        /// <typeparam name="T">The type representing the table or collection.</typeparam>
        /// <param name="name">Optional, parameter is only used in some implementations of the <see cref="IQueryContext"/></param>
        /// <returns></returns>
        IQuery<T> Query<T>(string name = null) where T : class, new();

        /// <summary>
        /// If <see cref="SuppressCompatabilityErrors"/> is false, will evaluate the current expression for common cross provider issues.
        /// </summary>
        /// <param name="expression">The expression to evaluate.</param>
        void EvaluateExpression(Expression expression);
    }
}
