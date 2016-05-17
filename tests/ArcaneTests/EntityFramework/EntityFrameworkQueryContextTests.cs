using System.Collections.ObjectModel;
using Arcane;
using Arcane.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Internal;
using Xunit;
using ArcaneTests.EntityFramework.Data;
using System;
using System.Linq;
using ArcaneTests.Models;

namespace ArcaneTests.EntityFramework
{
    public class EntityFrameworkQueryContextTests : ArcaneBaseTest
    {
        private const int Total = 100;
        private static readonly DateTime Date = new DateTime(2016, 6, 30, 0, 0, 0, DateTimeKind.Utc);


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
                    for (int i = 1; i <= Total; i++)
                    {
                        db.Authors.Add(new Author {
                            Id = i,
                            Name = $"First{i} Last{i}",
                            Books = new Collection<Book> {
                                new Book {
                                    Id = i,
                                    Name = $"C# Development\nBook #{i} of {Total}",
                                    PublishDate = Date.AddMonths(-(Total - i))
                                }
                            }
                        });
                    }

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
        public void GetTheFirst24Books()
        {
            var entities = Context.Query<Author>().Where(a => a.Id <= 24);
            Assert.True(entities.Count() == 24);
        }
    }
}