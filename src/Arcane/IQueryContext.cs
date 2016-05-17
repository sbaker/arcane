using System;
using System.Threading.Tasks;

namespace Arcane
{
    /// <summary>
    /// Provides an interface for an abstraction around access to <see cref="IQueryable{T}" /> data entity classes
    /// </summary>
    public interface IQueryContext : IDisposable
    {
        IQuery<T> Query<T>() where T : class, new();

        void SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
