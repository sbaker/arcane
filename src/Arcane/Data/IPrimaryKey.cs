namespace Arcane.Data
{
    /// <summary>
    /// Specifies that the implementer has a primary key.
    /// </summary>
    public interface IPrimaryKey
    {
        /// <summary>
        /// Returns the value of the unique identifier.
        /// </summary>
        /// <returns></returns>
        object GetKey();
    }

    /// <summary>
    /// Contains a property that is used as the primary key when being persisted.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IPrimaryKey<TKey> : IPrimaryKey
    {
        /// <summary>
        /// The unique identifier for this instance.
        /// </summary>
        TKey Id { get; set; }
    }
}