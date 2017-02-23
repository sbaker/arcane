using Cassandra;

// ReSharper disable once CheckNamespace
namespace Arcane.Data.Cassandra
{
    /// <summary>
    /// A factory for creating <see cref="CassandraDataStore"/>s.
    /// </summary>
    public class CassandraDataStoreFactory : DataStoreFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataStoreFactory"/> class.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="context"></param>
        public CassandraDataStoreFactory(ISession session, IQueryContext context) : base(context)
        {
            Session = session;
        }

        /// <summary>
        /// The Cassandra <see cref="ISession"/> for this instance.
        /// </summary>
        public ISession Session { get; }

        /// <summary>
        /// Creates an <see cref="IDataStore"/> for non-read operations.
        /// </summary>
        /// <returns></returns>
        public override IDataStore CreateStore()
        {
            return new CassandraDataStore(Session);
        }
    }
}