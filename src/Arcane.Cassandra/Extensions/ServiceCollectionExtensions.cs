using System;
using Arcane;
using Arcane.Cassandra;
using Cassandra;

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
        /// <param name="hosts"></param>
        /// <returns></returns>
        public static IServiceCollection AddArcaneWithCassandra(this IServiceCollection services, params string[] hosts)
        {
            return services.AddArcane(builder => builder.AddCassandra(hosts));
        }

        /// <summary>
        /// Configures Arcane to use cassandra for persistance.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IServiceCollection AddArcaneWithCassandra(this IServiceCollection services, Action<Builder> builder)
        {
            return services.AddArcane(b => b.AddCassandra(builder));
        }
    }
}