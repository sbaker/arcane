using Arcane;
using Arcane.NosDB;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides extension methods on <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configures Arcane to use cassandra for persistance.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IServiceCollection AddArcaneWithNosDB(this IServiceCollection services, string connectionString)
        {
            return services.AddArcane(builder => builder.AddNosDB(connectionString));
        }
    }
}