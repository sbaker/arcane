using Arcane;
using Arcane.MongoDB;
using ArcaneTests.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ArcaneTests.MongoDB
{
    public class MongoDbQueryContextTests : ArcaneBaseTest
    {
        public MongoDbQueryContextTests()
        {
            ContextFactory<IMongoDatabase>.OnContextNeeded = context => {
                var client = new MongoClient("mongodb://arcanetests01:arcanetests01@ds023912.mlab.com:23912/arcanetests");
                var database = client.GetDatabase("arcanetests");
                var collection = database.GetCollection<Author>("Authors");

                if (collection.Count(FilterDefinition<Author>.Empty) == 0L)
                {
                    collection.InsertMany(GetAuthors());
                }

                return database;
            };

            Context = new MongoDbQueryContext();
        }

        [Fact]
        public void ContextReturnsIQueryOfAuthorTest()
        {
            var entities = Context.Query<Author>();
            Assert.IsAssignableFrom<IQuery<Author>>(entities);
        }

        [Fact]
        public void GetTheFirst24Authors()
        {
            var entities = Context.Query<Author>().Where(a => a.Id <= 24);
            Assert.True(entities.Count() == 24);
        }
    }
}
