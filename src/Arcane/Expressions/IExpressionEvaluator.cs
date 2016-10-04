using System.Linq.Expressions;

namespace Arcane.Expressions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IExpressionEvaluator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        void Evaluate(Expression expression);
    }
}