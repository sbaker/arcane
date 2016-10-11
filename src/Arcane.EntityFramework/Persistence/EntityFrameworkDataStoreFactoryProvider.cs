using Arcane.EntityFramework.Internal;
using Arcane.Persistence;

namespace Arcane.EntityFramework.Persistence
{
    internal class EntityFrameworkDataStoreFactoryProvider : DataStoreFactoryProvider
    {
        private readonly IDbContextProvider _dbContextProvider;

        public EntityFrameworkDataStoreFactoryProvider(IDbContextProvider dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IDataStoreFactory GetDataStoreFactory(IQueryContext context)
        {
            return new EntityFrameworkDataStoreFactory(_dbContextProvider.GetContext(), context);
        }
    }
}