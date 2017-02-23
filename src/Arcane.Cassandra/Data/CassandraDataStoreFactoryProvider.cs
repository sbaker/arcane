using Arcane.Data;
using Cassandra;

// ReSharper disable once CheckNamespace
namespace Arcane.Data.Cassandra
{
    /// <summary>
    /// A provider that produces <see cref="IDataStoreFactory"/>s.
    /// </summary>
    public class CassandraDataStoreFactoryProvider : DataStoreFactoryProvider
    {
        /// <summary>
        /// Initializes a new instances of the <see cref="CassandraDataStoreFactoryProvider"/>.
        /// </summary>
        /// <param name="session"></param>
        public CassandraDataStoreFactoryProvider(ISession session)
        {
            Session = session;
        }

        private ISession Session { get; }

        /// <summary>
        /// Gets a <see cref="IDataStoreFactory"/> for creating <see cref="IDataStore"/>s.
        /// </summary>
        /// <returns></returns>
        public override IDataStoreFactory GetDataStoreFactory(IQueryContext context)
        {
            return new CassandraDataStoreFactory(Session, context);
        }
    }
}