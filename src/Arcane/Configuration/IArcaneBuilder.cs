using Microsoft.Extensions.DependencyInjection;

namespace Arcane.Configuration
{
    /// <summary>
    /// A class used for adding services to the <see cref="IServiceCollection"/>.
    /// </summary>
    public interface IArcaneBuilder
    {
        /// <summary>
        /// The current <see cref="IServiceCollection"/> for registering services.
        /// </summary>
        IServiceCollection Services { get; }
    }
}