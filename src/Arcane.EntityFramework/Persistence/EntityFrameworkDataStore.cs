using Arcane.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Arcane.EntityFramework.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    internal class EntityFrameworkDataStore : SaveOnDisposeDataStore
    {
        private readonly DbContext _context;

        /// <summary>
        /// 
        /// </summary>
        public EntityFrameworkDataStore(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparamref name="T"/>
        /// <param name="entity"></param>
        public override void Insert<T>(T entity)
        {
            _context.Add(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparamref name="T"/>
        /// <param name="entity"></param>
        public override void Update<T>(T entity)
        {
            _context.Update(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public override void Delete<T>(T entity)
        {
            _context.Remove(entity);
        }

        /// <summary>
        /// Calls to the wrapped implementation to persist the changes made.
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}