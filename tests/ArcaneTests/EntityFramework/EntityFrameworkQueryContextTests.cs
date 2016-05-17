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
            //ContextFactory<EntityDbContext>.OnContextNeeded = context => new EntityDbContext();
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
                    var authors = GetAuthors(Total);

                    db.SaveChanges();
                }
            }
        }

        [Fact]
        public void ContextReturnsIQueryOfEntityTest()
        {
            var entities = Context.Query<Author>();
            Assert.IsAssignableFrom<IQuery<Author>>(entities);
        }

        [Fact]
        public void InnerQueryIsInternalDbSetOfEntityTest()
        {
            var entities = Context.Query<Author>();
            Assert.IsAssignableFrom<InternalDbSet<Author>>(((Query<Author>)entities).InnerQuery);
        }

        [Fact]
        public void GetTheFirst24Authors()
        {
            var entities = Context.Query<Author>().Where(a => a.Id <= 24);
            Assert.True(entities.Count() == 24);
        }
    }
}