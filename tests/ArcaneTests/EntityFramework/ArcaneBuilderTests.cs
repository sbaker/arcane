using Arcane;
using ArcaneTests.EntityFramework.Data;
using ArcaneTests.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ArcaneTests.EntityFramework
{
    public class ArcaneBuilderTests
    {
        private readonly IServiceCollection _services = new ServiceCollection();
        
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
