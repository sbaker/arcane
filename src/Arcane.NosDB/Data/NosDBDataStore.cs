using Alachisoft.NosDB.Client;
using Alachisoft.NosDB.Client.Linq;
using Alachisoft.NosDB.Common.Server.Engine;

// ReSharper disable once CheckNamespace
namespace Arcane.Data.NosDB
{
    /// <summary>
    /// Contains methods for doing non-read operations on a Cassandra <see cref="Database"/>.
    /// </summary>
    public class NosDBDataStore : SaveOnDisposeDataStore
    {
        private readonly object _syncRoot = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="NosDBDataStore"/> class.
        /// </summary>
        /// <param name="session"></param>
        public NosDBDataStore(Database session)
        {
            Session = session;
        }

        private Database Session { get; }

        /// <inheritdoc />
        public override void Delete<T>(T entity)
        {
            GetUpdatable<T>().Delete(entity, WriteConcern.InMemory);
        }

        /// <inheritdoc />
        public override void Insert<T>(T entity)
        {
            GetUpdatable<T>().Insert(entity, WriteConcern.InMemory);
        }

        /// <inheritdoc />
        public override void Update<T>(T entity)
        {
            GetUpdatable<T>().Update(entity, WriteConcern.InMemory);
        }

        /// <inheritdoc />
        public override int SaveChanges()
        {
            return 0;
        }

        private DBUpdatable<T> GetUpdatable<T>()
        {
            return Session.GetDBCollection<T>(typeof(T).Name).AsUpdateable();
        }
    }
}