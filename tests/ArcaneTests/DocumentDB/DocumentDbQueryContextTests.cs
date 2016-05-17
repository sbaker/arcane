using Arcane;
using Arcane.DocumentDB;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Linq;

namespace ArcaneTests.DocumentDB
{
    public class DocumentDbQueryContextTests : ArcaneBaseTest
    {
        public DocumentDbQueryContextTests()
        {
            ContextFactory<Database>.OnContextNeeded = context => {
                var client = new DocumentClient(new Uri(""), "");

                var database = client.CreateDatabaseQuery().First();

                return database;
            };

            Context = new DocumentDbQueryContext();
        }
    }
}
