using System;
using System.Linq;
using System.Linq.Expressions;
using Arcane.Data;
using ArcaneTests.Models;

namespace ArcaneTests.Repositories
{
    public interface IRepository
    {
        T Get<T>(int id) where T : class, IRootEntity<int>, new();

        IQueryable<T> GetAll<T>(Expression<Func<T, bool>> predicate) where T : class, IRootEntity<int>, new();

        void Add<T>(T entity) where T : class, IRootEntity<int>, IFindable<T>, new();
    }

    public interface IRepository<T> where T : class, IRootEntity<int>, IFindable<T>, new()
    {
        T Get(int id);

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        void Add(T entity);
    }
}
