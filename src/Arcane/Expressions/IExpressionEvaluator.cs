using System.Linq.Expressions;

namespace Arcane.Expressions
{
    /// <summary>
    /// Provides a method for evaluating <see cref="Expression"/>s.
    /// </summary>
    public interface IExpressionEvaluator
    {
        /// <summary>
        /// Evaluates the provided <see cref="Expression"/> tree for compatability issues when working with mulitple data stores.
        /// </summary>
        /// <param name="expression"></param>
        void Evaluate(Expression expression);
    }
}