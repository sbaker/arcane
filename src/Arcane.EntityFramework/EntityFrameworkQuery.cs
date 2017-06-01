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

        //private DbSet<T> DbSet { get; }
        
        ///// <summary>
        ///// When implemented in a derived class, adds a new <typeparamref name="T"/> entity to the backing database or collection.
        ///// </summary>
        ///// <param name="entity">The entity to add.</param>
        //protected override void AddCore(T entity)
        //{
        //    DbSet.Add(entity);
        //}

        ///// <summary>
        ///// When implemented in a derived class, adds all the new <typeparamref name="T"/> entities to the backing database or collection.
        ///// </summary>
        ///// <param name="entities">The entities to add.</param>
        //protected override void AddCore(IEnumerable<T> entities)
        //{
        //    DbSet.AddRange(entities);
        //}

        ///// <summary>
        ///// When implemented in a derived class, deletes the <typeparamref name="T"/> entity from the backing database or collection.
        ///// </summary>
        ///// <param name="entity">The entity to delete.</param>
        //protected override void DeleteCore(T entity)
        //{
        //    DbSet.Remove(entity);
        //}

        ///// <summary>
        ///// When implemented in a derived class, deletes all the <typeparamref name="T"/> entities from the backing database or collection.
        ///// </summary>
        ///// <param name="entities">The entities to delete.</param>
        //protected override void DeleteCore(IEnumerable<T> entities)
        //{
        //    DbSet.RemoveRange(entities);
        //}

        ///// <summary>
        ///// When implemented in a derived class, updates the <typeparamref name="T"/> entity in the backing database or collection.
        ///// </summary>
        ///// <param name="entity">The entity to update.</param>
        //protected override void UpdateCore(T entity)
        //{
        //    DbSet.Update(entity);
        //}

        ///// <summary>
        ///// When implemented in a derived class, updates all the <typeparamref name="T"/> entities in the backing database or collection.
        ///// </summary>
        ///// <param name="entities">The entities to update.</param>
        //protected override void UpdateCore(IEnumerable<T> entities)
        //{
        //    DbSet.UpdateRange(entities);
        //}
    }
}
