using System;
using Arcane.Builder;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Arcane
{
    /// <summary>
    /// A class containing extension methods for use with the Arcane library.
    /// </summary>
    public static class ArcaneExtensions
    {
        /// <summary>
        /// Registers the base Arcane functionality to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="builderAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddArcane(this IServiceCollection services, Action<IArcaneBuilder> builderAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (builderAction == null)
            {
                throw new ArgumentNullException(nameof(builderAction));
            }

            services.AddScoped<IQueryContext, QueryContext>();

            var builder = new ArcaneBuilder(services);

            builderAction(builder);

            return services;
        }
    }
}
