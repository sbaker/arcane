
using System;

namespace Arcane
{
    /// <summary>
    /// Allows for centralized settings.
    /// </summary>
    public static class GlobalSettings
    {
        /// <summary>
        /// A setting to suppress compatability errors given to every <see cref="IQueryContext"/> created which can then be overwritten per context.
        /// </summary>
        public static bool SuppressCompatibilityErrors { get; set; } = true;

        /// <summary>
        /// The <see cref="IServiceProvider"/> used to retreive services.
        /// </summary>
        public static IServiceProvider Provider { get; set; }
    }
}
