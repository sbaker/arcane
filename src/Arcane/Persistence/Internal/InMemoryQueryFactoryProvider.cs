namespace Arcane.Persistence.Internal
{
    internal class InMemoryQueryFactoryProvider : QueryFactoryProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IQueryFactory GetQueryFactory(IQueryContext context)
        {
            return new InMemoryQueryFactory(context);
        }
    }
}
