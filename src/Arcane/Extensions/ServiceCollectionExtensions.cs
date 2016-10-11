using Arcane;
using Arcane.Persistence;
using Arcane.Persistence.Internal;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection.ArcaneInMemory
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 
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
