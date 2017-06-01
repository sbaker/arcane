using Arcane;
using ArcaneTests.EntityFramework.Data;
using ArcaneTests.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ArcaneTests.EntityFramework
{
    /// <summary>
    /// ArcaneBuilder Tests
    /// </summary>
    public class ArcaneBuilderTests
    {
        private readonly IServiceCollection _services = new ServiceCollection();
        
        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void Test()
        {
            _services.AddArcane(builder =>
            {
                //builder.For<AuthorRepository>().Use<EntityDbContext>();
            });
        }
    }
}
