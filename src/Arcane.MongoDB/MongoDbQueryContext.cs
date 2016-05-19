using System;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace Arcane.MongoDB
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class MongoDbQueryContext : QueryContext<IMongoDatabase>
    {
        public MongoDbQueryContext()
        {
        }

        public MongoDbQueryContext(IMongoDatabase database) : base(database)
        {
        }

        public override IQuery<T> Query<T>(string name = null)
        {
            return new MongoDbQuery<T>(Context.GetCollection<T>(name ?? $"{typeof(T).Name}s"), this);
        }

        protected override void EvaluateExpression(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
