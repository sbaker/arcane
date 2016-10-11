using Arcane.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Arcane.EntityFramework.Persistence
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