namespace Arcane.Data.Internal
{
    internal class InMemoryDataStoreFactoryProvider : DataStoreFactoryProvider
    {
        public override IDataStoreFactory GetDataStoreFactory(IQueryContext context)
        {
            return new InMemoryDataStoreFactory(context);
        }
    }
}
