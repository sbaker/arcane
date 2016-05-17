using Microsoft.Data.Entity;
using System.Threading.Tasks;

namespace Arcane.EntityFramework
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class EntityFrameworkQueryContext : IQueryContext
    {
        public EntityFrameworkQueryContext(DbContext context)
        {
            Context = context;
        }

        protected DbContext Context { get; }

        public IQuery<T> Query<T>() where T : class, new()
        {
            return new Query<T>(Context.Set<T>());
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
