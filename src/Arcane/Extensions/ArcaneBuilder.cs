using Microsoft.Extensions.DependencyInjection;

namespace Arcane
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ArcaneBuilder : IArcaneBuilder
    {
        private readonly IServiceCollection _services;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        protected ArcaneBuilder(IServiceCollection services)
        {
            _services = services;
        }

        /// <summary>
        /// 
        /// </summary>
        IServiceCollection IArcaneBuilder.Services => _services;
    }
}