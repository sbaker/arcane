using System;
using Microsoft.Data.Entity;

namespace Arcane.EntityFramework
{
    public class EntityFrameworkQuery<T> : Query<T> where T : class
    {
        public EntityFrameworkQuery(DbSet<T> dbSet, IQueryContext context) : base(dbSet, context)
        {
            DbSet = dbSet;
        }

        public DbSet<T> DbSet { get; set; }

        public override void Add(T entity)
        {
            DbSet.Add(entity);
        }
    }
}
