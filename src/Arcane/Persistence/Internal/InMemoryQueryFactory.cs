namespace Arcane.Persistence.Internal
{
    internal class InMemoryQueryFactory : QueryFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public InMemoryQueryFactory(IQueryContext context) : base(context)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override IQuery<T> CreateQuery<T>(string name = null)
        {
            return new InMemoryQuery<T>(InMemoryDataStore.GetInMemoryData<T>(), Context);
        }
    }
}