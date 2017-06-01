using Arcane.Configuration;
using Arcane.Data;
using Arcane.Data.MongoDB;
using Arcane.MongoDB.Conventions;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

// ReSharper disable once CheckNamespace
namespace Arcane.MongoDB
{
    /// <summary>
    /// 
    /// </summary>
    public static class ArcaneBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IArcaneBuilder AddMongoDB(this IArcaneBuilder builder, string connectionString)
        {
            return builder.AddMongoDB<DefaultMongoCollectionNamingConvention>(new MongoUrl(connectionString));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="mongoUrl"></param>
        /// <returns></returns>
        public static IArcaneBuilder AddMongoDB(this IArcaneBuilder builder,  MongoUrl mongoUrl)
        {
            return builder.AddMongoDB<DefaultMongoCollectionNamingConvention>(mongoUrl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IArcaneBuilder AddMongoDB<TNamingConvention>(this IArcaneBuilder builder, string connectionString) where TNamingConvention : class, IMongoCollectionNamingConvention
        {
            return builder.AddMongoDB<TNamingConvention>(new MongoUrl(connectionString));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="mongoUrl"></param>
        /// <returns></returns>
        public static IArcaneBuilder AddMongoDB<TNamingConvention>(this IArcaneBuilder builder,  MongoUrl mongoUrl) where TNamingConvention : class, IMongoCollectionNamingConvention
        {
            var client = new MongoClient(mongoUrl);
            builder.Services.AddScoped(provider => client.GetDatabase(mongoUrl.DatabaseName));
            builder.Services.AddScoped<IQueryFactoryProvider, MongoDBQueryFactoryProvider>();
            builder.Services.AddScoped<IDataStoreFactoryProvider, MongoDBDataStoreFactoryProvider>();
            builder.Services.AddSingleton<IMongoCollectionNamingConvention, TNamingConvention>();
            return builder;
        }
    }
}
