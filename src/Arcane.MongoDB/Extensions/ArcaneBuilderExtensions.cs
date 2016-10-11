using Arcane.Builder;
using Arcane.MongoDB.Conventions;
using Arcane.MongoDB.Persistence;
using Arcane.Persistence;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Arcane.MongoDB.Extensions
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
        public static IArcaneBuilder UseMongoDB(this IArcaneBuilder builder, string connectionString)
        {
            return builder.UseMongoDB<DefaultMongoCollectionNamingConvention>(new MongoUrl(connectionString));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="mongoUrl"></param>
        /// <returns></returns>
        public static IArcaneBuilder UseMongoDB(this IArcaneBuilder builder,  MongoUrl mongoUrl)
        {
            return builder.UseMongoDB<DefaultMongoCollectionNamingConvention>(mongoUrl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IArcaneBuilder UseMongoDB<TNamingConvention>(this IArcaneBuilder builder, string connectionString) where TNamingConvention : class, IMongoCollectionNamingConvention
        {
            return builder.UseMongoDB<TNamingConvention>(new MongoUrl(connectionString));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="mongoUrl"></param>
        /// <returns></returns>
        public static IArcaneBuilder UseMongoDB<TNamingConvention>(this IArcaneBuilder builder,  MongoUrl mongoUrl) where TNamingConvention : class, IMongoCollectionNamingConvention
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
