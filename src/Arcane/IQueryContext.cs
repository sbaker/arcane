using System;
using System.Linq;
using System.Threading.Tasks;

namespace Arcane
{
    /// <summary>
    /// Provides an interface for an abstraction around access to <see cref="IQueryable{T}" /> data entity classes.
    /// </summary>
    public interface IQueryContext : IDisposable
    {
        /// <summary>
        /// When implemented in a derived class, creates a query for the given <typeparamref name="T"/> table or collection.
        /// </summary>
        /// <typeparam name="T">The type representing the table or collection.</typeparam>
        /// <param name="name">Optional, parameter is only used in some implementations of the <see cref="IQueryContext"/></param>
        /// <returns></returns>
        IQuery<T> Query<T>(string name = null) where T : class, new();
    }
}
