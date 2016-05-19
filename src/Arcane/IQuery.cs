using System.Collections.Generic;
using System.Linq;

namespace Arcane
{
    public interface IQuery<T> : IOrderedQueryable<T>
    {
        IQueryContext Context { get; }


        /// <summary>
        /// Add a new <typeparamref name="T"/> entity to the backing database or collection.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        void Add(T entity);


        /// <summary>
        /// Add all the new <typeparamref name="T"/> entities to the backing database or collection.
        /// </summary>
        /// <param name="entities">The entity to add.</param>
        void Add(IEnumerable<T> entities);


        /// <summary>
        /// Deletes the <typeparamref name="T"/> entity from the backing database or collection.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        void Delete(T entity);


        /// <summary>
        /// Deletes all the <typeparamref name="T"/> entities from the backing database or collection.
        /// </summary>
        /// <param name="entities">The entity to add.</param>
        void Delete(IEnumerable<T> entities);
    }
}
