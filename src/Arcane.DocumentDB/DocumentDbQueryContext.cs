using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Arcane.DocumentDB
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class DocumentDbQueryContext : QueryContext<Database>
    {
        private DocumentClient _client;

        public DocumentDbQueryContext()
        {
            _client = ContextFactory<DocumentClient>.OnContextNeeded(this);
        }

        public DocumentDbQueryContext(DocumentClient client)
        {
            _client = client;
        }

        public override IQuery<T> Query<T>(string name = null)
        {
            return new Query<T>(Enumerable.Empty<T>().AsQueryable());
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
