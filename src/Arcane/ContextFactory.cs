using System;

namespace Arcane
{
    public static class ContextFactory<TContext>
    {
        public static Func<IQueryContext, TContext> OnContextNeeded;
    }
}