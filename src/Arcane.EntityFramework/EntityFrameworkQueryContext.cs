using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Arcane.EntityFramework
{
    /// <summary>
    /// An EntityFramework implementation of <see cref="IQueryContext"/> wrapping the base <see cref="DbContext"/>.
    /// </summary>
    public class EntityFrameworkQueryContext : EntityFrameworkQueryContext<DbContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public EntityFrameworkQueryContext(DbContext context) : base(context)
        {
        }
    }

    /// <summary>
    /// An EntityFramework implementation of <see cref="IQueryContext"/> wrapping a generic <typeparamref name="TContext"/>.
    /// </summary>
    /// <typeparam name="TContext">The <typeparamref name="TContext"/> to encapsulate.</typeparam>
    public class EntityFrameworkQueryContext<TContext> : QueryContext<TContext>, ISaveChanges where TContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public EntityFrameworkQueryContext(TContext context) : base(null, context)
        {
        }

        /// <summary>
        /// When implemented in a derived class, creates a query for the given <typeparamref name="T"/> model representing a table or collection.
        /// </summary>
        /// <typeparam name="T">The type representing the table or collection.</typeparam>
        /// <param name="name">Optional, parameter is only used in some implementations of the <see cref="IQueryContext"/></param>
        /// <returns></returns>
        public override IQuery<T> Query<T>(string name = null)
        {
            return new EntityFrameworkQuery<T>(Context.Set<T>(), this);
        }

        /// <summary>
        /// When implemented in a derived class will evaluate the <paramref name="expression"/> if <see cref="QueryContext.SuppressCompatabilityErrors"/> is false.
        /// </summary>
        /// <param name="expression"></param>
        protected override void EvaluateExpression(Expression expression)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Calls to the wrapped implementation to persist the changes made.
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        /// <summary>
        /// Asynchronously calls to the wrapped implementation to persist the changes made.
        /// </summary>
        /// <returns>A <see cref="Task"/> for later evaluation.</returns>
        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
