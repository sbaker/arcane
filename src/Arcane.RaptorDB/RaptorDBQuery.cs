using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcane.RaptorDB
{
    public class RaptorDBQuery<T> : Query<T>
    {
        /// <summary>
        /// Initializes an instance using the provided <paramref name="innerQuery"/> and <paramref name="context"/>.
        /// </summary>
        /// <param name="innerQuery"></param>
        /// <param name="context"></param>
        public RaptorDBQuery(IQueryable<T> innerQuery, IQueryContext context) : base(innerQuery, context)
        {
        }
    }
}
