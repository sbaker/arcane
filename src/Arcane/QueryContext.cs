using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Arcane.Expressions;
using Arcane.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Arcane
{
    /// <summary>
    /// An abstract implementation of <see cref="IQueryContext"/> with some basic functionality.
    /// </summary>
    public class QueryContext : IQueryContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider">The <see cref="IServiceProvider"/> used to retrieve services.</param>
        public QueryContext(IServiceProvider provider)
        {
            Provider = provider;
            ExpressionEvaluator = provider.GetService<IExpressionEvaluator>();

            var factoryProvider = provider.GetRequiredService<IQueryFactoryProvider>();
            ArcaneQueryFactory = factoryProvider.GetQueryFactory(this);

            var dataStoreProvider = provider.GetRequiredService<IDataStoreFactoryProvider>();
            StoreFactory = dataStoreProvider.GetDataStoreFactory(this);
        }

        /// <summary>
        /// 
        /// </summary>
        protected IExpressionEvaluator ExpressionEvaluator { get; set; }

        /// <summary>
        /// Deconstructs the current instance and allows for disposing of any resources.
        /// </summary>
        ~QueryContext()
        {
            Dispose(false);
        }

        /// <summary>
        /// The ServiceProvider responsible for retrieving dependencies for this QueryContext.
        /// </summary>
        public IServiceProvider Provider { get; }

        /// <summary>
        /// 
        /// </summary>
        public IDataStoreFactory StoreFactory { get; }

        /// <summary>
        /// 
        /// </summary>
        protected IQueryFactory ArcaneQueryFactory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IQueryContext IDataStoreFactory.Context => this;

        /// <summary>
        /// Returns true, if the current instance has been disposed, false otherwise.
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// A setting to suppress cross provider compatibility issues.
        /// </summary>
        public bool SuppressCompatibilityErrors { get; set; } = GlobalSettings.SuppressCompatibilityErrors;

        /// <summary>
        /// Disposes of the current instance's resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// When implemented in a derived class, creates a query for the given <typeparamref name="T"/> model representing a table or collection.
        /// </summary>
        /// <typeparam name="T">The type representing the table or collection.</typeparam>
        /// <param name="name">Optional, parameter is only used in some implementations of the <see cref="IQueryContext"/></param>
        /// <returns></returns>
        public virtual IQuery<T> Query<T>(string name = null) where T : class, new()
        {
            return ArcaneQueryFactory.CreateQuery<T>(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IDataStore CreateStore()
        {
            return StoreFactory.CreateStore();
        }

        /// <summary>
        /// If <see cref="IQueryContext.SuppressCompatibilityErrors"/> is false, will evaluate the current expression for common cross provider issues.
        /// </summary>
        /// <param name="expression">The expression to evaluate.</param>
        void IQueryContext.EvaluateExpression(Expression expression)
        {
            EvaluateExpression(expression);
        }

        /// <summary>
        /// When implemented in a derived class will evaluate the <paramref name="expression"/> if <see cref="SuppressCompatibilityErrors"/> is false.
        /// </summary>
        /// <param name="expression"></param>
        protected virtual void EvaluateExpression(Expression expression)
        {
            if (!SuppressCompatibilityErrors)
            {
                ExpressionEvaluator?.Evaluate(expression);
            }
        }

        /// <summary>
        /// Disposes of the current instance's resources.
        /// </summary>
        /// <param name="disposing">True if the object is wrapped in a using, false if the GC is collecting the current instance.</param>
        protected virtual void DisposeCore(bool disposing)
        {
        }

        /// <summary>
        /// Disposes of the current instance's resources.
        /// </summary>
        /// <param name="disposing">True if the object is wrapped in a using, false if the GC is collecting the current instance.</param>
        protected void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                DisposeCore(disposing);

                IsDisposed = true;
            }
        }
    }
}