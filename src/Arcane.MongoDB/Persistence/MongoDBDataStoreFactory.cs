using Arcane.MongoDB;
using MongoDB.Driver;

// ReSharper disable once CheckNamespace
namespace Arcane.Data.MongoDB
{
    internal class MongoDBDataStoreFactory : DataStoreFactory
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollectionNamingConvention _namingConvention;

        public MongoDBDataStoreFactory(IMongoDatabase database, IMongoCollectionNamingConvention namingConvention, IQueryContext context) : base(context)
        {
            _database = database;
            _namingConvention = namingConvention;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IDataStore CreateStore()
        {
            return new MongoDBDataStore(_database, _namingConvention);
        }
    }
}