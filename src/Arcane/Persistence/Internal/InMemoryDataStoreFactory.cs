namespace Arcane.Persistence.Internal
{
    internal class InMemoryDataStoreFactory : DataStoreFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public InMemoryDataStoreFactory(IQueryContext context) : base(context)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IDataStore CreateStore()
        {
            return new InMemoryDataStore();
        }
    }
}