using Arcane.Persistence;
using MongoDB.Driver;

namespace Arcane.MongoDB.Persistence
{
    internal class MongoDBDataStore : SaveOnDisposeDataStore
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollectionNamingConvention _namingConvention;
        
        private int _count;

        public MongoDBDataStore(IMongoDatabase database, IMongoCollectionNamingConvention namingConvention)
        {
            _database = database;
            _namingConvention = namingConvention;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public override void Insert<T>(T entity)
        {
            _count += 1;
            _database.GetCollection<T>(_namingConvention.GetNameFor<T>()).InsertOne(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public override void Update<T>(T entity)
        {
            _count += 1;
            _database.GetCollection<T>(_namingConvention.GetNameFor<T>()).UpdateOne(entity.GetExpression(), new ObjectUpdateDefinition<T>(entity));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public override void Delete<T>(T entity)
        {
            _count += 1;
            _database.GetCollection<T>(_namingConvention.GetNameFor<T>()).DeleteOne(entity.GetExpression());
        }

        /// <summary>
        /// Calls to the wrapped implementation to persist the changes made.
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            var count = _count;
            _count = 0;
            return count;
        }
    }
}