using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Arcane.EntityFramework.Internal
{
    internal class DbContextProvider<TDbContext> : IDbContextProvider<TDbContext> where TDbContext : DbContext
    {
        private readonly IServiceProvider _provider;

        public DbContextProvider(IServiceProvider provider)
        {
            _provider = provider;
        }

        public TDbContext GetDbContext()
        {
            return _provider.GetRequiredService<TDbContext>();
        }

        public DbContext GetContext()
        {
            return GetDbContext();
        }
    }
}