using Microsoft.Data.Entity;

namespace Arcane.EntityFramework
{
    public class EntityFrameworkQuery<T> : Query<T> where T : class
    {
        public EntityFrameworkQuery(DbSet<T> dbSet, IQueryContext context) : base(dbSet, context)
        {
            DbSet = dbSet;
        }

        private DbSet<T> DbSet { get; }

        protected override void AddCore(T entity)
        {
            DbSet.Add(entity);
        }
    }
}
