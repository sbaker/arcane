using MongoDB.Driver;

namespace Arcane.MongoDB
{
    internal class MongoDBQueryFactoryProvider : QueryFactoryProvider
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollectionNamingConvention _namingConvention;

        public MongoDBQueryFactoryProvider(IMongoDatabase database, IMongoCollectionNamingConvention namingConvention)
        {
            _database = database;
            _namingConvention = namingConvention;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IQueryFactory GetQueryFactory(IQueryContext context)
        {
            return new MongoDBQueryFactory(_database, _namingConvention, context);
        }
    }
}