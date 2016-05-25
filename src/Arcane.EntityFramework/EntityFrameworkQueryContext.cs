using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

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
    public class EntityFrameworkQueryContext<TContext> : QueryContext<TContext>, ISaveChanges where TContext : DbContext
    {
        public EntityFrameworkQueryContext()
        {
        }

        public EntityFrameworkQueryContext(TContext context) : base(context)
        {
        }

        public override IQuery<T> Query<T>(string name = null)
        {
            return new EntityFrameworkQuery<T>(Context.Set<T>(), this);
        }

        protected override void EvaluateExpression(Expression expression)
        {
            throw new System.NotImplementedException();
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
