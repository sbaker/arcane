using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcane.Persistence.Internal
{
    internal class InMemoryQuery<T> : Query<T>
    {
        /// <summary>
        /// Initializes an instance using the provided <paramref name="innerQuery"/> and <paramref name="context"/>.
        /// </summary>
        /// <param name="innerQuery"></param>
        /// <param name="context"></param>
        public InMemoryQuery(IQueryable<T> innerQuery, IQueryContext context) : base(innerQuery, context)
        {
        }
    }
}
