using System;
using System.Linq.Expressions;

namespace Arcane.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFindable<T>
    {
        /// <summary>
        /// 
        /// </summary>
        Expression<Func<T, bool>> GetExpression();
    }
}