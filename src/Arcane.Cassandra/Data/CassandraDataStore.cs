using System.Collections.Generic;
using Cassandra;
using Cassandra.Data.Linq;

// ReSharper disable once CheckNamespace
namespace Arcane.Data.Cassandra
{
    /// <summary>
    /// Contains methods for doing non-read operations on a Cassandra <see cref="Table{TEntity}"/>.
    /// </summary>
    public class CassandraDataStore : SaveOnDisposeDataStore
    {
        private readonly object _syncRoot = new object();
        private readonly IList<CqlCommand> _pendingOperations = new List<CqlCommand>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CassandraDataStore"/> class.
        /// </summary>
        /// <param name="session"></param>
        public CassandraDataStore(ISession session)
        {
            Session = session;
        }

        private ISession Session { get; }

        /// <inheritdoc />
        public override void Delete<T>(T entity)
        {
            var command = Session.GetTable<T>().DeleteIf(entity.GetExpression());

            lock (_syncRoot)
            {
                _pendingOperations.Add(command);
            }
        }

        /// <inheritdoc />
        public override void Insert<T>(T entity)
        {
            var command = Session.GetTable<T>().Insert(entity);

            lock (_syncRoot)
            {
                _pendingOperations.Add(command);
            }
        }

        /// <inheritdoc />
        public override void Update<T>(T entity)
        {
            var command = Session.GetTable<T>().UpdateIf(entity.GetExpression());

            lock (_syncRoot)
            {
                _pendingOperations.Add(command);
            }
        }

        /// <inheritdoc />
        public override int SaveChanges()
        {
            lock (_syncRoot)
            {
                var count = _pendingOperations.Count;

                for (int i = 0; i < count; i++)
                {
                    _pendingOperations[i].Execute();
                }

                _pendingOperations.Clear();

                return count;
            }
        }
    }
}