using System.Linq;

namespace Arcane
{
    public abstract class Query<T> : ArcaneQueryable<T>, IQuery<T>
    {
        protected Query(IQueryable<T> innerQuery, IQueryContext context) : base(innerQuery, context)
        {
        }

        #region IQuery implementation

        IQueryContext IQuery<T>.Context => Context;
        
        /// <summary>
        /// Add a new <typeparamref name="T"/> entity to the backing database or collection.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        void IQuery<T>.Add(T entity)
        {
            AddCore(entity);
        }

        protected abstract void AddCore(T entity);

        #endregion
    }
}