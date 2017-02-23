using Alachisoft.NosDB.Client;

// ReSharper disable once CheckNamespace
namespace Arcane.Data.NosDB
{
    /// <summary>
    /// A provider that produces <see cref="IDataStoreFactory"/>s.
    /// </summary>
    public class NosDBDataStoreFactoryProvider : DataStoreFactoryProvider
    {
        /// <summary>
        /// Initializes a new instances of the <see cref="NosDBDataStoreFactoryProvider"/>.
        /// </summary>
        /// <param name="database"></param>
        public NosDBDataStoreFactoryProvider(Database database)
        {
            Database = database;
        }

        private Database Database { get; }

        /// <summary>
        /// Gets a <see cref="IDataStoreFactory"/> for creating <see cref="IDataStore"/>s.
        /// </summary>
        /// <returns></returns>
        public override IDataStoreFactory GetDataStoreFactory(IQueryContext context)
        {
            return new NosDBDataStoreFactory(Database, context);
        }
    }
}