using Cassandra;
using Cassandra.Data.Linq;

namespace Arcane.Cassandra
{
    /// <summary>
    /// A provider for <see cref="CassandraQueryFactory"/> objects.
    /// </summary>
    public class CassandraQueryFactoryProvider : QueryFactoryProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CassandraQueryFactoryProvider"/> class.
        /// </summary>
        /// <param name="session"></param>
        public CassandraQueryFactoryProvider(ISession session)
        {
            Session = session;
        }

        private ISession Session { get; }

        /// <inheritdoc />
        public override IQueryFactory GetQueryFactory(IQueryContext context)
        {
            return new CassandraQueryFactory(Session, context);
        }
    }

    /// <summary>
    /// A factory for creating <see cref="CassandraQuery{T}"/> instances.
    /// </summary>
    public class CassandraQueryFactory : QueryFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CassandraQueryFactory"/> class.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="context"></param>
        public CassandraQueryFactory(ISession session, IQueryContext context) : base(context)
        {
            Session = session;
        }

        private ISession Session { get; }

        /// <inheritdoc />
        public override IQuery<T> CreateQuery<T>(string name = null)
        {
            return new CassandraQuery<T>(Session.GetTable<T>(), Context);
        }
    }
}