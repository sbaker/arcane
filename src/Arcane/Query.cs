using System.Collections.Generic;
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

        void IQuery<T>.Add(IEnumerable<T> entities)
        {
            AddCore(entities);
        }

        void IQuery<T>.Delete(T entity)
        {
            DeleteCore(entity);
        }

        void IQuery<T>.Delete(IEnumerable<T> entities)
        {
            DeleteCore(entities);
        }

        #endregion

        protected abstract void AddCore(T entity);

        protected abstract void AddCore(IEnumerable<T> entities);

        protected abstract void DeleteCore(T entity);

        protected abstract void DeleteCore(IEnumerable<T> entities);
    }
}