using System.Linq;
using Arcane;
using Arcane.MongoDB;
using ArcaneTests.Models;
using MongoDB.Driver;
using Xunit;

namespace ArcaneTests.MongoDB
{
    public class MongoDbQueryContextTests : ArcaneBaseTest
    {
        public MongoDbQueryContextTests()
        {
            ContextFactory<IMongoDatabase>.OnContextNeeded = context => {
                var client = new MongoClient("mongodb://localhost/arcanetests");
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

        [Fact]
        public void GetTheFirst24UsingRepository()
        {
            var entities = Repository.GetAll<Author>(a => a.Id <= 24);
            Assert.True(entities.Count() == 24);
        }

        [Fact]
        public void GetThe10MostRecentAuthorsUsingRepository()
        {
            var entities = AuthorRepository.GetMostRecent10Authors().ToList();
            Assert.True(entities.Count == 10);
        }
    }
}
