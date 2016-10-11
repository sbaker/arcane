using System.Collections.Generic;
using System.Linq;
using Arcane.Persistence;

namespace Arcane
{
    /// <summary>
    /// An interface that represents a wrapped <see cref="IQueryable{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQuery<T> : IOrderedQueryable<T>, IQueryContextReference
    {
        /// <summary>
        /// 
        /// </summary>
        IDataStoreFactory StoreFactory { get; set; }
        
        ///// <summary>
        ///// Add a new <typeparamref name="T"/> entity to the backing database or collection.
        ///// </summary>
        ///// <param name="entity">The entity to add.</param>
        //void Add(T entity);
        
        ///// <summary>
        ///// Add all the new <typeparamref name="T"/> entities to the backing database or collection.
        ///// </summary>
        ///// <param name="entities">The entities to add.</param>
        //void Add(IEnumerable<T> entities);
        
        ///// <summary>
        ///// Deletes the <typeparamref name="T"/> entity from the backing database or collection.
        ///// </summary>
        ///// <param name="entity">The entity to delete.</param>
        //void Delete(T entity);
        
        ///// <summary>
        ///// Deletes all the <typeparamref name="T"/> entities from the backing database or collection.
        ///// </summary>
        ///// <param name="entities">The entities to delete.</param>
        //void Delete(IEnumerable<T> entities);

        ///// <summary>
        ///// Updates the <typeparamref name="T"/> entity in the backing database or collection.
        ///// </summary>
        ///// <param name="entity">The entity to update.</param>
        //void Update(T entity);

        ///// <summary>
        ///// Updates all the <typeparamref name="T"/> entities in the backing database or collection.
        ///// </summary>
        ///// <param name="entities">The entities to update.</param>
        //void Update(IEnumerable<T> entities);
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IQueryContextReference
    {
        /// <summary>
        /// 
        /// </summary>
        IQueryContext Context { get; }
    }
}
