using Microsoft.EntityFrameworkCore;

namespace Arcane.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityFrameworkQuery<T> : Query<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbSet"></param>
        /// <param name="context"></param>
        public EntityFrameworkQuery(DbSet<T> dbSet, IQueryContext context) : base(dbSet, context)
        {
            //DbSet = dbSet;
        }
    }
}
