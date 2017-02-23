using Alachisoft.NosDB.Client;

// ReSharper disable once CheckNamespace
namespace Arcane.Data.NosDB
{
    /// <summary>
    /// A factory for creating <see cref="NosDBDataStore"/>s.
    /// </summary>
    public class NosDBDataStoreFactory : DataStoreFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataStoreFactory"/> class.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="context"></param>
        public NosDBDataStoreFactory(Database database, IQueryContext context) : base(context)
        {
            Database = database;
        }

        /// <summary>
        /// The NosDB <see cref="Alachisoft.NosDB.Client.Database"/> for this instance.
        /// </summary>
        public Database Database { get; }

        /// <summary>
        /// Creates an <see cref="IDataStore"/> for non-read operations.
        /// </summary>
        /// <returns></returns>
        public override IDataStore CreateStore()
        {
            return new NosDBDataStore(Database);
        }
    }
}