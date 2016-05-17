using System;
using System.Threading.Tasks;

namespace Arcane.DocumentDB
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class DocumentDbQueryContext : QueryContext
    {
        public DocumentDbQueryContext()
        {
        }

        public override IQuery<T> Query<T>(string name = null)
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
