using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Arcane;
using ArcaneTests.Models;

namespace ArcaneTests.Repositories
{
    public class Repository : IRepository
    {
        public IQueryContext Context { get; set; }

        public Repository(IQueryContext context)
        {
            Context = context;
        }

        public T Get<T>(int id) where T : class, IRootEntity<int>, new()
        {
            return Context.Query<T>().FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> predicate) where T : class, IRootEntity<int>, new()
        {
            return Context.Query<T>().Where(predicate);
        }

        public void Add<T>(T entity) where T : class, IRootEntity<int>, new()
        {
            Context.Query<T>().Add(entity);
        }
    }

    public class Repository<T> : IRepository<T> where T : class, IRootEntity<int>, new()
    {
        public IQueryContext Context { get; set; }

        public Repository(IQueryContext context)
        {
            Context = context;
        }

        public T Get(int id)
        {
            return Context.Query<T>().FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return Context.Query<T>().Where(predicate);
        }

        public void Add(T entity)
        {
            Context.Query<T>().Add(entity);
        }
    }
}
