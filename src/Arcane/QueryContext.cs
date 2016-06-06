using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Arcane
{
    /// <summary>
    /// An abstract implementation of <see cref="IQueryContext"/> with some basic functionality.
    /// </summary>
    public abstract class QueryContext : IQueryContext, ISaveChanges
    {
        /// <summary>
        /// Deconstructs the current instance and allows for disposing of any resources.
        /// </summary>
        ~QueryContext()
        {
            Dispose(false);
        }

        /// <summary>
        /// Returns true, if the current instance has been disposed, false otherwise.
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// A setting to suppress cross provider compatability issues.
        /// </summary>
        public bool SuppressCompatabilityErrors { get; set; } = GlobalSettings.SuppressCompatibilityErrors;

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
        public abstract IQuery<T> Query<T>(string name = null) where T : class, new();

        /// <summary>
        /// If <see cref="IQueryContext.SuppressCompatabilityErrors"/> is false, will evaluate the current expression for common cross provider issues.
        /// </summary>
        /// <param name="expression">The expression to evaluate.</param>
        void IQueryContext.EvaluateExpression(Expression expression)
        {
            if (!SuppressCompatabilityErrors)
            {
                EvaluateExpression(expression);
            }
        }

        /// <summary>
        /// When implemented in a derived class will evaluate the <paramref name="expression"/> if <see cref="SuppressCompatabilityErrors"/> is false.
        /// </summary>
        /// <param name="expression"></param>
        protected abstract void EvaluateExpression(Expression expression);
        
        /// <summary>
        /// Disposes of the current instance's resources.
        /// </summary>
        /// <param name="disposing">True if the object is wrapped in a using, false if the GC is collecting the current instance.</param>
        protected abstract void DisposeCore(bool disposing);

        /// <summary>
        /// An empty implementation of <see cref="ISaveChanges.SaveChanges"/>
        /// </summary>
        /// <returns></returns>
        protected virtual int SaveChangesCore()
        {
            return 0;
        }
        
        /// <summary>
        /// Asynchronously calls to the wrapped implementation to persist the changes made.
        /// </summary>
        /// <returns>A <see cref="Task"/> for later evaluation.</returns>
        protected virtual async Task<int> SaveChangesCoreAsync()
        {
            return await Task.FromResult(0);
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

        /// <summary>
        /// Calls to the wrapped implementation to persist the changes made.
        /// </summary>
        /// <returns></returns>
        int ISaveChanges.SaveChanges()
        {
            return SaveChangesCore();
        }

        /// <summary>
        /// Asynchronously calls to the wrapped implementation to persist the changes made.
        /// </summary>
        /// <returns>A <see cref="Task"/> for later evaluation.</returns>
        async Task<int> ISaveChanges.SaveChangesAsync()
        {
            return await SaveChangesCoreAsync();
        }
    }

    /// <summary>
    /// An abstract implementation of <see cref="IQueryContext"/> with some basic functionality and a strongly typed inner context.
    /// </summary>
    public abstract class QueryContext<TContext> : QueryContext
    {
        private TContext _context;

        /// <summary>
        /// When called from a derived class, initializes a new instance of the <see cref="QueryContext{TContext}"/> class.
        /// </summary>
        protected QueryContext()
        {
        }

        /// <summary>
        /// When called from a derived class, initializes a new instance of the <see cref="QueryContext{TContext}"/> class unsing the provided <paramref name="context"/>.
        /// </summary>
        /// <param name="context">The context to wrap.</param>
        protected QueryContext(TContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The wrapped <typeparamref name="TContext"/>.
        /// </summary>
        protected virtual TContext Context
        {
            get
            {
                if (_context == null)
                {
                    if (ContextFactory<TContext>.OnContextNeeded == null)
                    {
                        throw new Exception($"The context was not provided and the factory method:{nameof(ContextFactory<TContext>.OnContextNeeded)} was set on: {typeof(ContextFactory<TContext>)}");
                    }

                    _context = ContextFactory<TContext>.OnContextNeeded(this);
                }

                return _context;
            }
            set
            {
                _context = value;
            }
        }

        /// <summary>
        /// Disposes of the current instance's <see cref="Context"/> if it implements IDisposable.
        /// </summary>
        /// <param name="disposing">True if the object is wrapped in a using, false if the GC is collecting the current instance.</param>
        protected override void DisposeCore(bool disposing)
        {
            if (disposing)
            {
                (_context as IDisposable)?.Dispose();
            }
        }
    }
}