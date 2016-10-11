using System;
using Arcane;
using Arcane.Builder;
using Arcane.EntityFramework;
using Arcane.EntityFramework.Internal;
using Arcane.EntityFramework.Persistence;
using Arcane.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides extension methods for configuring EntityFramework on top of Arcane.
    /// </summary>
    public static class ArcaneBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="builder"></param>
        /// <param name="optionsBuilder"></param>
        /// <returns></returns>
        public static IArcaneBuilder UseEntityFramework<TDbContext>(this IArcaneBuilder builder, Action<DbContextOptionsBuilder> optionsBuilder) where TDbContext : DbContext
        {
            builder.Services.AddEntityFramework();
            builder.Services.AddScoped<IDataStoreFactoryProvider, EntityFrameworkDataStoreFactoryProvider>();
            builder.Services.AddScoped<IQueryFactoryProvider, EntityFrameworkQueryFactoryProvider>();
            builder.Services.AddScoped<IDbContextProvider, DbContextProvider<TDbContext>>();
            builder.Services.AddDbContext<TDbContext>(optionsBuilder);
            return builder;
        }
    }
}