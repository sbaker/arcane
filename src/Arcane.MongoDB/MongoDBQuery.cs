using MongoDB.Driver;

namespace Arcane.MongoDB
{
    public class MongoDbQuery<T> : Query<T>
    {
        public MongoDbQuery(IMongoCollection<T> collection, IQueryContext context) : base(collection.AsQueryable(), context)
        {
            Collection = collection;
        }

        public IMongoCollection<T> Collection { get; set; }

        public override void Add(T entity)
        {
            Collection.InsertOne(entity);
        }
    }
}
