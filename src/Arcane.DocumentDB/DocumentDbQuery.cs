using System.Linq;

namespace Arcane.DocumentDB
{
    public class DocumentDbQuery<T> : Query<T>
    {
        public DocumentDbQuery(IQueryable<T> innerQuery, IQueryContext context, DatabaseQueryConfig config) : base(innerQuery, context)
        {
            Config = config;
        }

        public DatabaseQueryConfig Config { get; }

        public override void Add(T entity)
        {
            Config.CreateDocument(entity);
        }
    }
}
