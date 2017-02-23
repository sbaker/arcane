using Arcane.Configuration;
using Arcane.Data;
using Arcane.Data.NosDB;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Arcane.NosDB
{
    /// <summary>
    /// Contains extension methods for configuring Cassandra.
    /// </summary>
    public static class ArcaneBuilderExtensions
    {
        /// <summary>
        /// Configures NosDB using the provided connection string.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IArcaneBuilder AddNosDB(this IArcaneBuilder builder, string connectionString)
        {
            builder.Services.AddScoped(provider => Alachisoft.NosDB.Client.NosDB.GetDatabase(connectionString));
            builder.Services.AddScoped<IQueryFactoryProvider, NosDBQueryFactoryProvider>();
            builder.Services.AddScoped<IDataStoreFactoryProvider, NosDBDataStoreFactoryProvider>();
            return builder;
        }
    }
}
