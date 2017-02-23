namespace Arcane.Data.Internal
{
    internal class InMemoryQueryFactory : QueryFactory
    {
        public InMemoryQueryFactory(IQueryContext context) : base(context)
        {
        }

        public override IQuery<T> CreateQuery<T>(string name = null)
        {
            return new InMemoryQuery<T>(InMemoryDataStore.GetInMemoryData<T>(), Context);
        }
    }
}