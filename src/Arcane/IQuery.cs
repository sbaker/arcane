using System.Linq;

namespace Arcane
{
    /// <summary>
    /// An interface that represents a wrapped <see cref="IQueryable{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQuery<out T> : IOrderedQueryable<T>, IQueryContextReference
    {
        ///// <summary>
        ///// 
        ///// </summary>
        //IDataStoreFactory StoreFactory { get; set; }
    }

    /// <summary>
    /// Contains an <see cref="IQueryContext"/> reference that this instance is associated with.
    /// </summary>
    public interface IQueryContextReference
    {
        /// <summary>
        /// The <see cref="IQueryContext"/> this instance is associated with.
        /// </summary>
        IQueryContext Context { get; }
    }
}
