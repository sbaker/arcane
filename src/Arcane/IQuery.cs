using System.Linq;

namespace Arcane
{
    public interface IQuery<out T> : IOrderedQueryable<T>
    {
    }
}
