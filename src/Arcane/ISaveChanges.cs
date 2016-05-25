using System.Threading.Tasks;

namespace Arcane
{
    public interface ISaveChanges
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}