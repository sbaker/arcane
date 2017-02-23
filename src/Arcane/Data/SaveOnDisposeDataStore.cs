namespace Arcane.Data
{
    /// <summary>
    /// An abstract implementation of <see cref="IDataStore"/> that automatically calls SaveChanges when disposed.
    /// </summary>
    public abstract class SaveOnDisposeDataStore : IDataStore
    {
        /// <summary>
        /// Inserts or marks the <paramref name="entity"/> as new.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public abstract void Insert<T>(T entity) where T : class, IFindable<T>;

        /// <summary>
        /// Updates or marks the <paramref name="entity"/> as modified.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public abstract void Update<T>(T entity) where T : class, IFindable<T>;

        /// <summary>
        /// Deletes or marks the <paramref name="entity"/> for deletion.
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