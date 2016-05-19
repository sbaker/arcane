using System.Collections.Generic;
using System.Linq;
using Arcane;

namespace ArcaneTests.InMemoryTests.Data
{
    public class InMemoryQuery<T> : Query<T>
    {
        public IList<T> List { get; set; }

        public InMemoryQuery(IList<T> list, IQueryContext context) : base(list.AsQueryable(), context)
        {
            List = list;
        }

        public override void Add(T entity)
        {
            List.Add(entity);
        }
    }
}
