namespace Arcane
{
    /// <summary>
    /// A factory for creating <see cref="IQuery{T}"/> instances.
    /// </summary>
    public interface IQueryFactory
    {
        /// <summary>
        /// The <see cref="IQueryContext"/> this instance is associated with.
        /// </summary>
        IQueryContext Context { get; }

        /// <summary>
        /// Creates an <see cref="IQuery{T}"/> for creating read operations.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Creates an <see cref="IQuery{T}"/> for creating read operations.</returns>
        IQuery<T> CreateQuery<T>(string name = null) where T : class;
    }

    /// <summary>
    /// A base implementation of <see cref="IQueryFactory"/>.
    /// </summary>
    public abstract class QueryFactory : IQueryFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryFactory"/> class.
        /// </summary>
        /// <param name="context"></param>
        protected QueryFactory(IQueryContext context)
        {
            Context = context;
        }

        /// <summary>
        /// The <see cref="IQueryContext"/> this instance is associated with.
        /// </summary>
        public IQueryContext Context { get; }

        /// <summary>
        /// When implemented in a derived class, creates an <see cref="IQuery{T}"/> for creating read operations.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Creates an <see cref="IQuery{T}"/> for creating read operations.</returns>
        public abstract IQuery<T> CreateQuery<T>(string name = null) where T : class;
    }
}