using System.Linq;

namespace Arcane
{
    /// <summary>
    /// An abstract implementation of <see cref="IQuery{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Query<T> : ArcaneQueryable<T>, IQuery<T>
    {
        /// <summary>
        /// Initializes an instance using the provided <paramref name="innerQuery"/> and <paramref name="context"/>.
        /// </summary>
        /// <param name="innerQuery"></param>
        /// <param name="context"></param>
        protected Query(IQueryable<T> innerQuery, IQueryContext context) : base(innerQuery, context)
        {
        }

        IQueryContext IQueryContextReference.Context => Context;
    }
}