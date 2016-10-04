﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Arcane.EntityFramework.Factories
{
    ///
    internal class EntityFrameworkArcaneQueryProvider : IArcaneQueryFactoryProvider
    {
        private readonly IDbContextProvider _dbContextProvider;

        public EntityFrameworkArcaneQueryProvider(IDbContextProvider dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public IArcaneQueryFactory GetQueryFactory(IQueryContext context)
        {
            return new EntityFrameworkQueryFactory(_dbContextProvider.GetContext(), context);
        }
    }

    internal class EntityFrameworkQueryFactory : ArcaneQueryFactory
    {
        private readonly DbContext _dbContext;

        public EntityFrameworkQueryFactory(DbContext dbContext, IQueryContext context) : base(context)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override IQuery<T> CreateQuery<T>(string name = null)
        {
            return new EntityFrameworkQuery<T>(_dbContext.Set<T>(), Context);
        }
    }
}