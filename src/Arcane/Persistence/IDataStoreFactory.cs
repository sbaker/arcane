namespace Arcane.Persistence
{
    /// <summary>
    /// Containes methods for creating <see cref="IDataStore"/>s.
    /// </summary>
    public interface IDataStoreFactory
    {
        /// <summary>
        /// The <see cref="IQueryContext"/> this instance is associated with.
        /// </summary>
        IQueryContext Context { get; }

        /// <summary>
        /// Creates an <see cref="IDataStore"/> for non-read operations.
        /// </summary>
        /// <returns></returns>
        IDataStore CreateStore();
    }

    /// <summary>
    /// A base class for creating <see cref="IDataStore"/>s.
    /// </summary>
    public abstract class DataStoreFactory : IDataStoreFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataStoreFactory"/> class.
        /// </summary>
        /// <param name="context"></param>
        protected DataStoreFactory(IQueryContext context)
        {
            Context = context;
        }

        /// <summary>
        /// The <see cref="IQueryContext"/> this instance is associated with.
        /// </summary>
        public IQueryContext Context { get; }

        /// <summary>
        /// When implemented in a derived class, creates an <see cref="IDataStore"/> for non-read operations.
        /// </summary>
        /// <returns></returns>
        public abstract IDataStore CreateStore();
    }
}