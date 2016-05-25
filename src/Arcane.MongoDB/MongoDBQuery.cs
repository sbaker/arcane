using System;
using System.Collections.Generic;
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

        protected override void AddCore(IEnumerable<T> entities)
        {
            Collection.InsertMany(entities);
        }

        protected override void DeleteCore(T entity)
        {
            throw new NotImplementedException();
            //Collection.DeleteOne(Builders<T>.Filter.In(e => e, new[] {entity}));
        }

        protected override void DeleteCore(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
            //Collection.DeleteMany(Builders<T>.Filter.In(e => e, entities));
        }

        protected override void UpdateCore(T entity)
        {
            throw new NotImplementedException();
            //Collection.UpdateOne(Builders<T>.Filter.Exists(e => e, entity), Builders<T>.Update.);
        }

        protected override void UpdateCore(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
            //ollection.UpdateMany(Builders<T>.Filter.In(e => e, entities), Builders<T>.Update.);
        }
    }
}
