using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Arcane.EntityFramework.Internal
{
    internal class DbContextProvider<TDbContext> : IDbContextProvider where TDbContext : DbContext
    {
        private readonly IServiceProvider _provider;

        public DbContextProvider(IServiceProvider provider)
        {
            _provider = provider;
        }

        public DbContext GetContext()
        {
            return _provider.GetRequiredService<TDbContext>();
        }
    }
}