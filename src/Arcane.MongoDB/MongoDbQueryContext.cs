using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcane.MongoDB
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class MongoDbQueryContext : QueryContext
    {
        public MongoDbQueryContext()
        {
            throw new NotImplementedException();
        }

        public override IQuery<T> Query<T>()
        {
            throw new NotImplementedException();
        }

        public override void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public override Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        protected override void DisposeCore(bool disposing)
        {
            throw new NotImplementedException();
        }
    }
}
