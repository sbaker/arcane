using Arcane;
using Arcane.EntityFramework;
using ArcaneTests.EntityFramework.Data;
using ArcaneTests.Models;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Internal;
using System.Linq;
using Xunit;

namespace ArcaneTests.EntityFramework
{
    public class EntityFrameworkQueryContextTests : ArcaneBaseTest
    {
        public EntityFrameworkQueryContextTests()
        {
            ContextFactory<DbContext>.OnContextNeeded = context => new EntityDbContext();
            Context = new EntityFrameworkQueryContext();

            EnsureTestDatabase();
        }

        private static void EnsureTestDatabase()
        {
            using (var db = new EntityDbContext())
            {
                if (db.Database.EnsureCreated())
                {
                    db.Authors.AddRange(GetAuthors());

                    db.SaveChanges();
                }
            }
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