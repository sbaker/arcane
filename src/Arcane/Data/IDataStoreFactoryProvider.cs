namespace Arcane.Data
{
    /// <summary>
    /// A provider for <see cref="IDataStoreFactory"/>s.
    /// </summary>
    public interface IDataStoreFactoryProvider
    {
        /// <summary>
        /// Gets a <see cref="IDataStoreFactory"/> for creating <see cref="IDataStore"/>s.
        /// </summary>
        /// <returns></returns>
        IDataStoreFactory GetDataStoreFactory(IQueryContext context);
    }

    /// <summary>
    /// A base provider for <see cref="IDataStoreFactory"/>s.
    /// </summary>
    public abstract class DataStoreFactoryProvider : IDataStoreFactoryProvider
    {
        /// <summary>
        /// When implemented in a derived class, gets a <see cref="IDataStoreFactory"/> for creating <see cref="IDataStore"/>s.
        /// </summary>
        /// <returns></returns>
        public abstract IDataStoreFactory GetDataStoreFactory(IQueryContext context);
    }
}