using Microsoft.EntityFrameworkCore;

namespace Arcane.EntityFramework.Internal
{
    internal interface IDbContextProvider
    {
        DbContext GetContext();
    }
}