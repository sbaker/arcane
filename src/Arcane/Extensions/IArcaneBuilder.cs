using System;
using Microsoft.Extensions.DependencyInjection;

namespace Arcane
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