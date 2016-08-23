using System;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace Arcane.MongoDB
{
    /// <summary>
    /// 
    /// </summary>
    public class MongoDbQueryContext : QueryContext<IMongoDatabase>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        public MongoDbQueryContext(IMongoDatabase database) : base(null, database)
        {
        }

        /// <summary>
        /// When implemented in a derived class, creates a query for the given <typeparamref name="T"/> model representing a table or collection.
        /// </summary>
        /// <typeparam name="T">The type representing the table or collection.</typeparam>
        /// <param name="name">Optional, parameter is only used in some implementations of the <see cref="IQueryContext"/></param>
        /// <returns></returns>
        public override IQuery<T> Query<T>(string name = null)
        {
            return new MongoDbQuery<T>(Context.GetCollection<T>(name ?? $"{typeof(T).Name}s"), this);
        }

        /// <summary>
        /// When implemented in a derived class will evaluate the <paramref name="expression"/> if <see cref="QueryContext.SuppressCompatabilityErrors"/> is false.
        /// </summary>
        /// <param name="expression"></param>
        protected override void EvaluateExpression(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
