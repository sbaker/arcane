
namespace Arcane
{
    /// <summary>
    /// A provider of <see cref="IQueryFactory"/> objects.
    /// </summary>
    public interface IQueryFactoryProvider
    {
        /// <summary>
        /// Gets an <see cref="IQueryFactory"/> for constructing <see cref="IQuery{T}"/>s.
        /// </summary>
        /// <returns>Gets an <see cref="IQueryFactory"/> for constructing <see cref="IQuery{T}"/>s.</returns>
        IQueryFactory GetQueryFactory(IQueryContext context);
    }

    /// <summary>
    /// A provider of <see cref="IQueryFactory"/> objects.
    /// </summary>
    public abstract class QueryFactoryProvider : IQueryFactoryProvider
    {
        /// <summary>
        /// When implemented in a derived class, gets an <see cref="IQueryFactory"/> for constructing <see cref="IQuery{T}"/>s.
        /// </summary>
        /// <returns>Gets an <see cref="IQueryFactory"/> for constructing <see cref="IQuery{T}"/>s.</returns>
        public abstract IQueryFactory GetQueryFactory(IQueryContext context);
    }
}