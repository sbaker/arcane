namespace Arcane.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDataStoreFactory
    {
        /// <summary>
        /// 
        /// </summary>
        IQueryContext Context { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IDataStore CreateStore();
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class DataStoreFactory : IDataStoreFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected DataStoreFactory(IQueryContext context)
        {
            Context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        public IQueryContext Context { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IDataStore CreateStore();
    }
}