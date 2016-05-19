﻿using System;
using System.Linq.Expressions;

namespace Arcane
{
    public abstract class QueryContext : IQueryContext
    {
        ~QueryContext()
        {
            Dispose(false);
        }

        public bool IsDisposed { get; private set; }

        public bool SuppressCompatabilityErrors { get; set; } = GlobalSettings.SuppressCompatibilityErrors;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public abstract IQuery<T> Query<T>(string name = null) where T : class, new();

        void IQueryContext.EvaluateExpression(Expression expression)
        {
            if (!SuppressCompatabilityErrors)
            {
                EvaluateExpression(expression);
            }
        }

        protected abstract void EvaluateExpression(Expression expression);

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
                (Context as IDisposable)?.Dispose();
            }
        }
    }
}