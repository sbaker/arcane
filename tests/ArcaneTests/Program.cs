using ArcaneTests.EntityFramework.Data;
using ArcaneTests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ArcaneTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddArcaneEntityFramework(builder => builder.For<AuthorRepository>().Use<EntityDbContext>());

            var provider = services.BuildServiceProvider();
            var repository = provider.GetService<IAuthorRepository>();
        }
    }
}