﻿using System.Linq;

namespace Arcane
{
    public interface IQuery<T> : IOrderedQueryable<T>, IQueryProvider
    {
        IQueryContext Context { get; }

        void Add(T entity);
    }
}
