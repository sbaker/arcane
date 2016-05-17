using LiteDB;
using Arcane;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace IQueryLiteDb
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class LiteDbQueryContext : IQueryContext
    {
        public LiteDbQueryContext(LiteDatabase database)
        {
            throw new NotImplementedException();
            Database = database;
        }

        protected LiteDatabase Database { get; }

        public IQuery<T> Query<T>() where T : class, new()
        {
            throw new NotImplementedException();
            return new Query<T>(Database.GetCollection<T>(nameof(T)).FindAll().AsQueryable());
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
