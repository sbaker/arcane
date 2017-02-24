using Arcane.Data;

namespace Arcane.RaptorDB.Data
{
    public class RaptorDBDataStore : SaveOnDisposeDataStore
    {
        /// <summary>
        /// Inserts or marks the <paramref name="entity"/> as new.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public override void Insert<T>(T entity)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Updates or marks the <paramref name="entity"/> as modified.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public override void Update<T>(T entity)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deletes or marks the <paramref name="entity"/> for deletion.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public override void Delete<T>(T entity)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Calls to the wrapped implementation to persist the changes made.
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}