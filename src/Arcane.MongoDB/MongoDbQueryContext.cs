using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcane.MongoDB
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class MongoDbQueryContext : IQueryContext
    {
        public MongoDbQueryContext()
        {
        }

        public IQuery<T> Query<T>() where T : class, new()
        {
            throw new NotImplementedException();
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
