using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Arcane;

namespace ArcaneTests.InMemoryTests.Data
{
    public class InMemoryQuery<T> : Query<T>
    {
        public InMemoryQuery(IList<T> list, IQueryContext context) : base(list.AsQueryable(), context)
        {
            List = list;
        }
        
        private IList<T> List { get; }

        protected override void AddCore(T entity)
        {
            List.Add(entity);
        }
    }
}
