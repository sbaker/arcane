using Microsoft.Data.Entity;
using System.Threading.Tasks;

namespace Arcane.EntityFramework
{
    /// <summary>
    /// An EntityFramework implementation of <see cref="IQueryContext"/> wrapping the base <see cref="DbContext"/>.
    /// </summary>
    public class EntityFrameworkQueryContext : EntityFrameworkQueryContext<DbContext>
    {
        public EntityFrameworkQueryContext()
        {
        }

        public EntityFrameworkQueryContext(DbContext context) : base(context)
        {
        }
    }

    /// <summary>
    /// An EntityFramework implementation of <see cref="IQueryContext"/> wrapping a generic <see cref="TContext"/>.
    /// </summary>
    /// <typeparam name="TContext">The <typeparamref name="TContext"/> to encapsulate.</typeparam>
    public class EntityFrameworkQueryContext<TContext> : QueryContext<TContext> where TContext : DbContext
    {
        public EntityFrameworkQueryContext()
        {
        }

        public EntityFrameworkQueryContext(TContext context) : base(context)
        {
        }

        public override IQuery<T> Query<T>(string name = null)
        {
            return new Query<T>(Context.Set<T>());
        }

        public override void SaveChanges()
        {
            Context.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
