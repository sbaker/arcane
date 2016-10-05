using Microsoft.Extensions.DependencyInjection;

namespace Arcane.Builder
{
    /// <summary>
    /// 
    /// </summary>
    public class ArcaneBuilder : IArcaneBuilder
    {
        private readonly IServiceCollection _services;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public ArcaneBuilder(IServiceCollection services)
        {
            _services = services;
        }

        /// <summary>
        /// 
        /// </summary>
        IServiceCollection IArcaneBuilder.Services => _services;
    }
}