using System.Linq;

namespace Arcane.NosDB
{
    public class NosDBQuery<T> : Query<T>
    {
        public NosDBQuery(IQueryable<T> innerQuery, IQueryContext context) : base(innerQuery, context)
        {
        }
    }
}
