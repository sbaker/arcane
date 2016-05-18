using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcane.MongoDB
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class MongoDbQueryContext : QueryContext<IMongoDatabase>
    {
        public MongoDbQueryContext()
        {
        }

        public MongoDbQueryContext(IMongoDatabase database) : base(database)
        {
        }

        protected override IQueryable<T> CreateQueryable<T>(string name = null)
        {
            return Context.GetCollection<T>(name ?? $"{typeof(T).Name}s").AsQueryable();
        }
    }
}
