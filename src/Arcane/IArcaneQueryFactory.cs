namespace Arcane
{
    /// <summary>
    /// 
    /// </summary>
    public interface IArcaneQueryFactory
    {
        /// <summary>
        /// 
        /// </summary>
        IQueryContext Context { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IQuery<T> CreateQuery<T>(string name = null) where T : class;
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class ArcaneQueryFactory : IArcaneQueryFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected ArcaneQueryFactory(IQueryContext context)
        {
            Context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        public IQueryContext Context { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public abstract IQuery<T> CreateQuery<T>(string name = null) where T : class;
    }
}