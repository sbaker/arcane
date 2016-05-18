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
            ContextFactory<DatabaseQueryConfig>.OnContextNeeded = context => {
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
            collection = client.CreateDocumentCollectionAsync(database.SelfLink, collection).Result;

            var authors = GetAuthors();

            for (var i = 0; i < authors.Length; i++)
            {
                client.CreateDocumentAsync(collection.SelfLink, authors[i]).Wait();
            }

            return database;
        }

        [Fact]
        public void GetTheFirst24UsingRepository()
        {
            //var entities = Repository.GetAll<Author>(a => a.Id <= 24);
            //Assert.True(entities.Count() == 24);
        }
    }
}
