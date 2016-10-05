using Microsoft.Extensions.DependencyInjection;

namespace Arcane.Builder
{
    /// <summary>
    /// 
    /// </summary>
    public interface IArcaneBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        IServiceCollection Services { get; }
    }
}