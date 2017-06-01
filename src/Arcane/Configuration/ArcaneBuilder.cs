using Microsoft.Extensions.DependencyInjection;

namespace Arcane.Configuration
{
    /// <summary>
    /// A class used for adding services to the <see cref="IServiceCollection"/>.
    /// Note: The base implementation has no functionaly. Extension methods provided in other libraries supply the functionality.
    /// </summary>
    public class ArcaneBuilder : IArcaneBuilder
    {
        private readonly IServiceCollection _services;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArcaneBuilder"/> class.
        /// </summary>
        /// <param name="services"></param>
        public ArcaneBuilder(IServiceCollection services)
        {
            _services = services;
        }

        /// <summary>
        /// The current <see cref="IServiceCollection"/> instance for registering services.
        /// </summary>
        IServiceCollection IArcaneBuilder.Services => _services;
    }
}