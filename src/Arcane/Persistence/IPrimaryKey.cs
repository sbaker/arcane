namespace Arcane.Persistence
{
    /// <summary>
    /// Contains a property that is used as the primary key when being persisted.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IPrimaryKey<TKey>
    {
        /// <summary>
        /// The unique identifier for this instance.
        /// </summary>
        TKey Id { get; set; }
    }
}