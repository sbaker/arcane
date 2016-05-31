using System.Collections.Generic;
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

        protected override void AddCore(T entity)
        {
            Config.CreateDocument(entity);
        }

        protected override void AddCore(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                AddCore(entity);
            }
        }

        protected override void DeleteCore(T entity)
        {
            Config.DeleteDocument(entity);
        }

        protected override void DeleteCore(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                DeleteCore(entity);
            }
        }

        protected override void UpdateCore(T entity)
        {
            Config.UpdateDocument(entity);
        }

        protected override void UpdateCore(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                UpdateCore(entity);
            }
        }
    }
}
