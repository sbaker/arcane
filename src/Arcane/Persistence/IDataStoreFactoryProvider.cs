namespace Arcane.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDataStoreFactoryProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IDataStoreFactory GetDataStoreFactory(IQueryContext context);
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class DataStoreFactoryProvider : IDataStoreFactoryProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IDataStoreFactory GetDataStoreFactory(IQueryContext context);
    }
}