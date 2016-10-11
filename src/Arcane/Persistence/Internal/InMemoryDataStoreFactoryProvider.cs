namespace Arcane.Persistence.Internal
{
    internal class InMemoryDataStoreFactoryProvider : DataStoreFactoryProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IDataStoreFactory GetDataStoreFactory(IQueryContext context)
        {
            return new InMemoryDataStoreFactory(context);
        }
    }
}
