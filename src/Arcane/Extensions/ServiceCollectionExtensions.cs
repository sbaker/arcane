using Arcane;
using Arcane.Data;
using Arcane.Data.Internal;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection.ArcaneInMemory
{
    /// <summary>
    /// Provides an extension method for using in-memory data.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the services necessary for using in-memory data.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddArcaneWithInMemoryData(this IServiceCollection services)
        {
            return services.AddArcane(builder =>
            {
                builder.Services.AddScoped<IDataStoreFactoryProvider, InMemoryDataStoreFactoryProvider>();
                builder.Services.AddScoped<IQueryFactoryProvider, InMemoryQueryFactoryProvider>();
            });
        }
    }
}
