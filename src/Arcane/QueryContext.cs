﻿using System;
using System.Threading.Tasks;

namespace Arcane
{
    public abstract class QueryContext : IQueryContext
    {
        ~QueryContext()
        {
            Dispose(false);
        }

        public bool IsDisposed { get; private set; }

        public abstract IQuery<T> Query<T>() where T : class, new();

        public abstract void SaveChanges();

        public abstract Task<int> SaveChangesAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected abstract void DisposeCore(bool disposing);

        protected void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                DisposeCore(disposing);

                IsDisposed = true;
            }
        }
    }

    public abstract class QueryContext<TContext> : QueryContext
    {
        private TContext _context;

        protected QueryContext()
        {
        }

        protected QueryContext(TContext context)
        {
            _context = context;
        }

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

        protected override void DisposeCore(bool disposing)
        {
            if (disposing)
            {
                var disposable = Context as IDisposable;

                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }
    }
}