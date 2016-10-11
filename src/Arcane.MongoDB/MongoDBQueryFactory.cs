using MongoDB.Driver;

namespace Arcane.MongoDB
{
    internal class MongoDBQueryFactory : QueryFactory
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollectionNamingConvention _namingConvention;

        public MongoDBQueryFactory(IMongoDatabase database, IMongoCollectionNamingConvention namingConvention, IQueryContext context) : base(context)
        {
            _database = database;
            _namingConvention = namingConvention;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override IQuery<T> CreateQuery<T>(string name = null)
        {
            return new MongoDbQuery<T>(_database.GetCollection<T>(name ?? _namingConvention.GetNameFor<T>()), Context);
        }
    }
}