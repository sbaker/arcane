﻿namespace Arcane.Persistence
{
    /// <summary>
    /// An abstract implementation of <see cref="IDataStore"/> that automatically calls SaveChanges when disposed.
    /// </summary>
    public abstract class SaveOnDisposeDataStore : IDataStore
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public abstract void Insert<T>(T entity) where T : class, IFindable<T>;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public abstract void Update<T>(T entity) where T : class, IFindable<T>;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public abstract void Delete<T>(T entity) where T : class, IFindable<T>;

        /// <summary>
        /// Calls to the wrapped implementation to persist the changes made.
        /// </summary>
        /// <returns></returns>
        public abstract int SaveChanges();

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            SaveChanges();
        }
    }
}