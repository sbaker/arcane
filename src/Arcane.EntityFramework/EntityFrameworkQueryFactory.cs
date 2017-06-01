using Microsoft.EntityFrameworkCore;

namespace Arcane.EntityFramework
{
    internal class EntityFrameworkQueryFactory : QueryFactory
    {
        private readonly DbContext _dbContext;

        public EntityFrameworkQueryFactory(DbContext dbContext, IQueryContext context) : base(context)
        {
            _dbContext = dbContext;
        }

        public override IQuery<T> CreateQuery<T>(string name = null)
        {
            return new EntityFrameworkQuery<T>(_dbContext.Set<T>(), Context);
        }
    }
}