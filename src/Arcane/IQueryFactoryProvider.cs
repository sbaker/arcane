
namespace Arcane
{
    /// <summary>
    /// 
    /// </summary>
    public interface IQueryFactoryProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IQueryFactory GetQueryFactory(IQueryContext context);
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class QueryFactoryProvider : IQueryFactoryProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IQueryFactory GetQueryFactory(IQueryContext context);
    }
}