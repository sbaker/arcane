using System.Collections.Generic;
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

        /// <summary>
        /// Add all the new <typeparamref name="T"/> entities to the backing database or collection.
        /// </summary>
        /// <param name="entities">The entities to add.</param>
        void IQuery<T>.Add(IEnumerable<T> entities)
        {
            AddCore(entities);
        }

        /// <summary>
        /// Deletes the <typeparamref name="T"/> entity from the backing database or collection.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        void IQuery<T>.Delete(T entity)
        {
            DeleteCore(entity);
        }

        /// <summary>
        /// Deletes all the <typeparamref name="T"/> entities from the backing database or collection.
        /// </summary>
        /// <param name="entities">The entities to delete.</param>
        void IQuery<T>.Delete(IEnumerable<T> entities)
        {
            DeleteCore(entities);
        }

        /// <summary>
        /// Updates the <typeparamref name="T"/> entity in the backing database or collection.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void IQuery<T>.Update(T entity)
        {
            UpdateCore(entity);
        }

        /// <summary>
        /// Updates all the <typeparamref name="T"/> entities in the backing database or collection.
        /// </summary>
        /// <param name="entities">The entities to update.</param>
        void IQuery<T>.Update(IEnumerable<T> entities)
        {
            UpdateCore(entities);
        }

        #endregion

        /// <summary>
        /// When implemented in a derived class, adds a new <typeparamref name="T"/> entity to the backing database or collection.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        protected abstract void AddCore(T entity);

        /// <summary>
        /// When implemented in a derived class, adds all the new <typeparamref name="T"/> entities to the backing database or collection.
        /// </summary>
        /// <param name="entities">The entities to add.</param>
        protected abstract void AddCore(IEnumerable<T> entities);

        /// <summary>
        /// When implemented in a derived class, deletes the <typeparamref name="T"/> entity from the backing database or collection.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        protected abstract void DeleteCore(T entity);

        /// <summary>
        /// When implemented in a derived class, deletes all the <typeparamref name="T"/> entities from the backing database or collection.
        /// </summary>
        /// <param name="entities">The entities to delete.</param>
        protected abstract void DeleteCore(IEnumerable<T> entities);

        /// <summary>
        /// When implemented in a derived class, updates the <typeparamref name="T"/> entity in the backing database or collection.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        protected abstract void UpdateCore(T entity);

        /// <summary>
        /// When implemented in a derived class, updates all the <typeparamref name="T"/> entities in the backing database or collection.
        /// </summary>
        /// <param name="entities">The entities to update.</param>
        protected abstract void UpdateCore(IEnumerable<T> entities);
    }
}