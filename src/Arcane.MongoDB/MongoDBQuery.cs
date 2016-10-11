using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Arcane.MongoDB
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MongoDbQuery<T> : Query<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="context"></param>
        public MongoDbQuery(IMongoCollection<T> collection, IQueryContext context) : base(collection.AsQueryable(), context)
        {
            Collection = collection;
        }

        private IMongoCollection<T> Collection { get; }

        ///// <summary>
        ///// When implemented in a derived class, adds a new <typeparamref name="T"/> entity to the backing database or collection.
        ///// </summary>
        ///// <param name="entity">The entity to add.</param>
        //protected override void AddCore(T entity)
        //{
        //    Collection.InsertOne(entity);
        //}

        ///// <summary>
        ///// When implemented in a derived class, adds all the new <typeparamref name="T"/> entities to the backing database or collection.
        ///// </summary>
        ///// <param name="entities">The entities to add.</param>
        //protected override void AddCore(IEnumerable<T> entities)
        //{
        //    Collection.InsertMany(entities);
        //}

        ///// <summary>
        ///// When implemented in a derived class, deletes the <typeparamref name="T"/> entity from the backing database or collection.
        ///// </summary>
        ///// <param name="entity">The entity to delete.</param>
        //protected override void DeleteCore(T entity)
        //{
        //    throw new NotImplementedException();
        //    //Collection.DeleteOne(Builders<T>.Filter.In(e => e, new[] {entity}));
        //}

        ///// <summary>
        ///// When implemented in a derived class, deletes all the <typeparamref name="T"/> entities from the backing database or collection.
        ///// </summary>
        ///// <param name="entities">The entities to delete.</param>
        //protected override void DeleteCore(IEnumerable<T> entities)
        //{
        //    throw new NotImplementedException();
        //    //Collection.DeleteMany(Builders<T>.Filter.In(e => e, entities));
        //}

        ///// <summary>
        ///// When implemented in a derived class, updates the <typeparamref name="T"/> entity in the backing database or collection.
        ///// </summary>
        ///// <param name="entity">The entity to update.</param>
        //protected override void UpdateCore(T entity)
        //{
        //    throw new NotImplementedException();
        //    //Collection.UpdateOne(Builders<T>.Filter.Exists(e => e, entity), Builders<T>.Update.);
        //}

        ///// <summary>
        ///// When implemented in a derived class, updates all the <typeparamref name="T"/> entities in the backing database or collection.
        ///// </summary>
        ///// <param name="entities">The entities to update.</param>
        //protected override void UpdateCore(IEnumerable<T> entities)
        //{
        //    throw new NotImplementedException();
        //    //ollection.UpdateMany(Builders<T>.Filter.In(e => e, entities), Builders<T>.Update.);
        //}
    }
}
