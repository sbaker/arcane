using Arcane.EntityFramework.Internal;

namespace Arcane.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    internal class EntityFrameworkQueryFactoryProvider : QueryFactoryProvider
    {
        private readonly IDbContextProvider _dbContextProvider;

        public EntityFrameworkQueryFactoryProvider(IDbContextProvider dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IQueryFactory GetQueryFactory(IQueryContext context)
        {
            return new EntityFrameworkQueryFactory(_dbContextProvider.GetContext(), context);
        }
    }
}