using Arcane;
using Arcane.DocumentDB;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Linq;
using ArcaneTests.Models;
using Microsoft.Azure.Documents;
using Xunit;

namespace ArcaneTests.DocumentDB
{
    public class DocumentDbQueryContextTests : ArcaneBaseTest
    {
        public DocumentDbQueryContextTests()
        {
            ContextFactory<DatabaseQueryConfig>.OnContextNeeded = context =>
            {
                var client = new DocumentClient(new Uri(""), "");

                var database = client.CreateDatabaseQuery().Where(db => db.Id == "Arcane").ToArray().FirstOrDefault()
                    ?? EnsureTestDatabase(client, "Arcane");

                var config = new DatabaseQueryConfig
                {
                    Client = client,
                    Database = database
                };

                return config;
            };

            Context = new DocumentDbQueryContext();
        }

        private static Database EnsureTestDatabase(DocumentClient client, string databaseName)
        {
            var database = new Database { Id = databaseName };
            database = client.CreateDatabaseAsync(database).Result;

            var collection = new DocumentCollection { Id = "Authors" };
            collection = DocumentClientHelper.CreateDocumentCollectionWithRetriesAsync(client, database.Id, collection).Result;

            var authors = GetAuthors();

            for (var i = 0; i < authors.Length; i++)
            {
                client.CreateDocumentAsync(collection.SelfLink, authors[i], disableAutomaticIdGeneration:true).Wait();
            }

            return database;
        }

        [Fact]
        public void GetTheFirst24UsingRepository()
        {
            // TODO: Test failes due to DocumentDB creating a unique identifier
            // TODO: field behind the scenes. Find an alternative way to make
            // TODO: identifiers work cross provider.
            // Json.Net throws here saying it can't convert from string to int due to 
            // document db creating an id field automatically.
            //var entities = Repository.GetAll<Author>(a => a.Id <= 24);
            //Assert.True(entities.Count() == 24);
        }
    }
}
