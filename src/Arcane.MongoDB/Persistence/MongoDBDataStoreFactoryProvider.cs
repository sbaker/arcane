using Arcane.MongoDB;
using MongoDB.Driver;

// ReSharper disable once CheckNamespace
namespace Arcane.Data.MongoDB
{
    internal class MongoDBDataStoreFactoryProvider : DataStoreFactoryProvider
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollectionNamingConvention _namingConvention;

        public MongoDBDataStoreFactoryProvider(IMongoDatabase database, IMongoCollectionNamingConvention namingConvention)
        {
            _database = database;
            _namingConvention = namingConvention;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IDataStoreFactory GetDataStoreFactory(IQueryContext context)
        {
            return new MongoDBDataStoreFactory(_database, _namingConvention, context);
        }
    }
}
