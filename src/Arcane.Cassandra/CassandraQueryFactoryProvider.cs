using Cassandra;

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
}