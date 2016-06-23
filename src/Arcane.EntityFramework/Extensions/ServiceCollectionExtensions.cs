using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using Arcane;
using Arcane.EntityFramework;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides extension methods on <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="builderAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddArcaneEntityFramework(this IServiceCollection services, Action<IArcaneBuilder> builderAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (builderAction == null)
            {
                throw new ArgumentNullException(nameof(builderAction));
            }

            var builder = new EntityFrameworkArcaneBuilder(services);

            builderAction(builder);

            return services;
        }

        private class EntityFrameworkArcaneBuilder : ArcaneBuilder
        {
            public EntityFrameworkArcaneBuilder(IServiceCollection services) : base(services)
            {
                //services.AddScoped(BaseQueryContext.Mask<IQueryContext>);
            }
        }
    }

    /// <summary>
    /// Provides extension methods for configuring EntityFramework on top of Arcane.
    /// </summary>
    public static class ArcaneBuilderExtensions
    {
        //public static IArcaneBuilder Add<TForImplementation, TDbContext>(this IArcaneBuilder builder) where TForImplementation : class where TDbContext : DbContext
        //{
        //    return builder.For<TForImplementation>().Use<TDbContext>();
        //}

        //public static IForBuilder<TService> For<TService>(this IArcaneBuilder builder) where TService : class
        //{
        //    return new ForBuilder<TService>(builder);
        //}
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IForBuilder<in TService>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <returns></returns>
        IArcaneBuilder Use<TDbContext>() where TDbContext : DbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TImplementation"></typeparam>
        /// <typeparam name="TDbContext"></typeparam>
        /// <returns></returns>
        IArcaneBuilder Use<TImplementation, TDbContext>() where TImplementation : TService where TDbContext : DbContext;
    }

    internal class ForBuilder<TService> : IForBuilder<TService>
    {
        private readonly IArcaneBuilder _builder;

        public ForBuilder(IArcaneBuilder builder)
        {
            _builder = builder;
        }

        public IArcaneBuilder Use<TDbContext>() where TDbContext : DbContext
        {
            return Use<TService, TDbContext>();
        }

        public IArcaneBuilder Use<TImplementation, TDbContext>() where TImplementation : TService where TDbContext : DbContext
        {
            //BaseQueryContext.Registry.TryAdd(typeof(TConcrete), typeof(TDbContext));
            //_builder.Services.AddScoped<EntityFrameworkQueryContext<TDbContext>>();

            //_builder.Services.Add(new ArcaneServiceDescriptor());
            return _builder;
        }
    }

    internal class BaseQueryContext : IQueryContext
    {
        public static readonly Type ContextType = typeof(EntityFrameworkQueryContext<>);

        public static ConcurrentDictionary<Type, Type> Registry { get; } = new ConcurrentDictionary<Type, Type>();

        public static TDbContext Mask<TDbContext>(IServiceProvider provider) where TDbContext : IQueryContext
        {
            var mask = new QueryContextFactoryMask<TDbContext>(provider);
            return mask;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool SuppressCompatabilityErrors { get; set; }

        public IQuery<T> Query<T>(string name = null) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public void EvaluateExpression(Expression expression)
        {
            throw new NotImplementedException();
        }
    }

    internal class QueryContextFactoryMask<TQueryContext>
    {
        private readonly IServiceProvider _provider;

        public QueryContextFactoryMask(IServiceProvider provider)
        {
            _provider = provider;
        }

        public static implicit operator TQueryContext(QueryContextFactoryMask<TQueryContext> mask)
        {
            throw new NotImplementedException();
            //StackFrame frame = new StackFrame(1);
            //var method = frame.GetMethod();
            //var type = method.DeclaringType;
            //var name = method.Name;
            //if (type.DeclaringType == null)
            //{
            //    throw new InvalidOperationException();
            //}

            //return (TQueryContext)mask._provider.GetService(BaseQueryContext.ContextType.MakeGenericType(
            //    BaseQueryContext.Registry[type.DeclaringType]
            //));
        }
    }
}