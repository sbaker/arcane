using System;

namespace Arcane.Data
{
    /// <summary>
    /// Represents a data store for persisting entities.
    /// </summary>
    public interface IDataStore : ISaveChanges, IDisposable
    {
        /// <summary>
        /// Inserts or marks the <paramref name="entity"/> as new.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Insert<T>(T entity) where T : class, IFindable<T>;

        /// <summary>
        /// Updates or marks the <paramref name="entity"/> as modified.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Update<T>(T entity) where T : class, IFindable<T>;
        
        /// <summary>
        /// Deletes or marks the <paramref name="entity"/> for deletion.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Delete<T>(T entity) where T : class, IFindable<T>;
    }
}