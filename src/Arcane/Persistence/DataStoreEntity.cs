using System;
using System.Linq.Expressions;

namespace Arcane.Persistence
{
    /// <summary>
    /// A base class for persisted entities.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TFindable"></typeparam>
    public abstract class DataStoreEntity<TKey, TFindable> : IPrimaryKey<TKey>, IFindable<TFindable> where TFindable : IPrimaryKey<TKey>
    {
        /// <inheritdoc />
        public TKey Id { get; set; }
        
        /// <inheritdoc />
        public virtual Expression<Func<TFindable, bool>> GetExpression()
        {
            // TODO: I don't like that i have to use .Equals() here and not ==.
            return e => e.Id.Equals(Id);
            //return e => e.Id == Id;
        }
    }
}