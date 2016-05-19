using MongoDB.Driver;

namespace Arcane.MongoDB
{
    public class MongoDbQuery<T> : Query<T>
    {
        public MongoDbQuery(IMongoCollection<T> collection, IQueryContext context) : base(collection.AsQueryable(), context)
        {
            Collection = collection;
        }

        private IMongoCollection<T> Collection { get; }

        protected override void AddCore(T entity)
        {
            Collection.InsertOne(entity);
        }
    }
}
