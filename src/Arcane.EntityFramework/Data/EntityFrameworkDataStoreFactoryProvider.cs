using Arcane.EntityFramework.Internal;

// ReSharper disable once CheckNamespace
namespace Arcane.Data.EntityFramework
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