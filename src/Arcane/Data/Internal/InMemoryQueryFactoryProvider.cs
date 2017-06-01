namespace Arcane.Data.Internal
{
    internal class InMemoryQueryFactoryProvider : QueryFactoryProvider
    {
        public override IQueryFactory GetQueryFactory(IQueryContext context)
        {
            return new InMemoryQueryFactory(context);
        }
    }
}
