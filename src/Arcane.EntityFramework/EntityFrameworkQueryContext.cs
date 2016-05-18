using Microsoft.Data.Entity;
using System.Linq;
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

        protected override IQueryable<T> CreateQueryable<T>(string name = null)
        {
            return Context.Set<T>();
        }
    }
}
