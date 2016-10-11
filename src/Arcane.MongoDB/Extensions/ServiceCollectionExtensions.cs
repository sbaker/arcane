using System;
using Arcane;
using Arcane.MongoDB;
using Arcane.MongoDB.Extensions;
using MongoDB.Driver;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides extension methods on <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IServiceCollection AddArcaneWithMongoDB(this IServiceCollection services, string connectionString)
        {
            return services.AddArcane(builder => builder.UseMongoDB(connectionString));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="mongoUrl"></param>
        /// <returns></returns>
        public static IServiceCollection AddArcaneWithMongoDB(this IServiceCollection services, MongoUrl mongoUrl)
        {
            return services.AddArcane(builder => builder.UseMongoDB(mongoUrl));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IServiceCollection AddArcaneWithMongoDB<TNamingConvention>(this IServiceCollection services, string connectionString) where TNamingConvention : class, IMongoCollectionNamingConvention
        {
            return services.AddArcane(builder => builder.UseMongoDB<TNamingConvention>(connectionString));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="mongoUrl"></param>
        /// <returns></returns>
        public static IServiceCollection AddArcaneWithMongoDB<TNamingConvention>(this IServiceCollection services, MongoUrl mongoUrl) where TNamingConvention : class, IMongoCollectionNamingConvention
        {
            return services.AddArcane(builder => builder.UseMongoDB<TNamingConvention>(mongoUrl));
        }
    }
}