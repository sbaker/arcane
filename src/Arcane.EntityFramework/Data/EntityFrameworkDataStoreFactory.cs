using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace Arcane.Data.EntityFramework
{
    internal class EntityFrameworkDataStoreFactory : DataStoreFactory
    {
        private readonly DbContext _dbContext;

        public EntityFrameworkDataStoreFactory(DbContext dbContext, IQueryContext context) : base(context)
        {
            _dbContext = dbContext;
        }

        public override IDataStore CreateStore()
        {
            return new EntityFrameworkDataStore(_dbContext);
        }
    }
}