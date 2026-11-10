using Microsoft.EntityFrameworkCore;

namespace Arcane.EntityFramework.Internal
{
    internal interface IDbContextProvider
    {
        DbContext GetBaseDbContext();
    }

    internal interface IDbContextProvider<out TDbContext> : IDbContextProvider where TDbContext : DbContext
    {
        TDbContext GetDbContext();
    }
}