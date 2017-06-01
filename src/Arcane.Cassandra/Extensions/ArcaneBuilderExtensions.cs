using System;
using Arcane.Configuration;
using Arcane.Data;
using Arcane.Data.Cassandra;
using Cassandra;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Arcane.Cassandra
{
    /// <summary>
    /// Contains extension methods for configuring Cassandra.
    /// </summary>
    public static class ArcaneBuilderExtensions
    {
        /// <summary>
        /// Configures Cassandra using the provided hosts.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="clusterAction"></param>
        /// <returns></returns>
        public static IArcaneBuilder AddCassandra(this IArcaneBuilder builder, Action<Builder> clusterAction)
        {
            var clusterBuilder = Cluster.Builder();
            clusterAction(clusterBuilder);
            var cluster = clusterBuilder.Build();
            builder.Services.AddScoped(provider => cluster.Connect());
            builder.Services.AddScoped<IQueryFactoryProvider, CassandraQueryFactoryProvider>();
            builder.Services.AddScoped<IDataStoreFactoryProvider, CassandraDataStoreFactoryProvider>();
            return builder;
        }

        /// <summary>
        /// Configures Cassandra using the provided hosts.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="hosts"></param>
        /// <returns></returns>
        public static IArcaneBuilder AddCassandra(this IArcaneBuilder builder, params string[] hosts)
        {
            return builder.AddCassandra(b => b.AddContactPoints(hosts));
        }
    }
}
