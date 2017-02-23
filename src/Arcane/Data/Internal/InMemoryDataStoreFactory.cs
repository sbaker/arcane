namespace Arcane.Data.Internal
{
    internal class InMemoryDataStoreFactory : DataStoreFactory
    {
        public InMemoryDataStoreFactory(IQueryContext context) : base(context)
        {
        }
        
        public override IDataStore CreateStore()
        {
            return new InMemoryDataStore();
        }
    }
}