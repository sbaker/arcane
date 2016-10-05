
namespace Arcane
{
    /// <summary>
    /// 
    /// </summary>
    public interface IArcaneQueryFactoryProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IArcaneQueryFactory GetQueryFactory(IQueryContext context);
    }
}