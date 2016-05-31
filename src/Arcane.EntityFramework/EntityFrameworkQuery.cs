using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

        protected override void AddCore(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }

        protected override void DeleteCore(T entity)
        {
            DbSet.Remove(entity);
        }

        protected override void DeleteCore(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }

        protected override void UpdateCore(T entity)
        {
            DbSet.Update(entity);
        }

        protected override void UpdateCore(IEnumerable<T> entities)
        {
            DbSet.UpdateRange(entities);
        }
    }
}
