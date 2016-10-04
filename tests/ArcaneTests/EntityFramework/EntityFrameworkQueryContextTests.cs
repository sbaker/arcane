using System;
using System.Data.SQLite;
using Arcane;
using ArcaneTests.EntityFramework.Data;
using ArcaneTests.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ArcaneTests.EntityFramework
{
    internal class EntityFrameworkQueryContextTests : ArcaneBaseTest
    {
        public EntityFrameworkQueryContextTests() : base(new ServiceProviderFactory())
        {
            EnsureTestDatabase();
        }

        private void EnsureTestDatabase()
        {
            using (var db = Provider.GetService<EntityDbContext>())
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
        public void GetTheFirst24UsingRepositorySelectAnonymous()
        {
            var entities = Repository.GetAll<Author>(a => a.Id <= 24).Select(a => new { a.Name });
            Assert.True(entities.Count() == 24);
        }

        [Fact]
        public void GetThe10MostRecentAuthorsUsingRepository()
        {
            var entities = AuthorRepository.GetMostRecent10Authors().ToList();
            Assert.True(entities.Count == 10);
        }

        [Fact]
        public void GetTheAuthorsByFirstNameStartsWithFirst1UsingRepository()
        {
            var entities = AuthorRepository.GetAuthorsByFirstName("First1").ToList();
            Assert.True(entities.Count == 12);
        }

        [Fact]
        public void GetTheAuthorsByFirstNameStartsWithFirst1UsingRepositoryNameCheck()
        {
            var entities = AuthorRepository.GetAuthorsByFirstName("First2").ToList();
            Assert.True(entities.Count == 11);
            Assert.True(entities.All(t => t.Name.StartsWith("First2")));
        }

        private class ServiceProviderFactory : IServiceProviderFactory
        {
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public IServiceProvider CreateServiceProvider()
            {
                var services = new ServiceCollection();

                var connectionStringBuilder = new SQLiteConnectionStringBuilder {
                    DataSource = "test.db"
                };

                services.AddArcane(b => b.UseEntityFramework<EntityDbContext>(options => options.UseSqlite(connectionStringBuilder.ToString())));

                return services.BuildServiceProvider();
            }
        }
    }
}