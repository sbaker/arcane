using System;
using System.Linq.Expressions;

namespace Arcane.Data
{
    /// <summary>
    /// Provides a method returning an <see cref="Expression"/> that can be used to locate the current instance.
    /// </summary>
    public interface IFindable<T>
    {
        /// <summary>
        /// Returns an <see cref="Expression"/> that can be used to locate the current instance.
        /// </summary>
        Expression<Func<T, bool>> GetExpression();
    }
}