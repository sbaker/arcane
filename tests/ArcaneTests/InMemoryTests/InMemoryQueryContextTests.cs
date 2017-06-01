using Arcane;
using ArcaneTests.InMemoryTests.Data;
using ArcaneTests.Models;
using System.Linq;
using Xunit;

namespace ArcaneTests.InMemoryTests
{
    internal class InMemoryQueryContextTests : ArcaneBaseTest
    {
        public InMemoryQueryContextTests() : base(null)
        {
            //Context = new InMemoryQueryContext(GetAuthors());
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
