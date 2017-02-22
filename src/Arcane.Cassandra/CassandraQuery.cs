using System.Linq;
using Cassandra.Data.Linq;

namespace Arcane.Cassandra
{
    /// <summary>
    /// Represents a read operation for a Cassandra database.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CassandraQuery<T> : Query<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CassandraQuery{T}"/> class.
        /// </summary>
        /// <param name="innerQuery"></param>
        /// <param name="context"></param>
        public CassandraQuery(IQueryable<T> innerQuery, IQueryContext context) : base(innerQuery, context)
        {
        }
    }
}
