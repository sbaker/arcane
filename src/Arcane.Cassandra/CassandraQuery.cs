using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Cassandra;
using Cassandra.Data.Linq;

namespace Arcane.Cassandra
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CassandraQuery<T> : Query<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="innerQuery"></param>
        /// <param name="context"></param>
        public CassandraQuery(Table<T> innerQuery, IQueryContext context) : base(innerQuery, context)
        {
            Table = innerQuery;
        }

        private Table<T> Table { get; set; }

        ///// <summary>
        ///// Adds a new <typeparamref name="T"/> entity to the backing database or collection.
        ///// </summary>
        ///// <param name="entity">The entity to add.</param>
        //protected override void AddCore(T entity)
        //{
        //    Table.Insert(entity).Execute();
        //}

        ///// <summary>
        ///// Adds all the new <typeparamref name="T"/> entities to the backing database or collection.
        ///// </summary>
        ///// <param name="entities">The entities to add.</param>
        //protected override void AddCore(IEnumerable<T> entities)
        //{
        //    foreach (var entity in entities)
        //    {
        //        AddCore(entity);
        //    }
        //}

        ///// <summary>
        ///// Deletes the <typeparamref name="T"/> entity from the backing database or collection.
        ///// </summary>
        ///// <param name="entity">The entity to delete.</param>
        //protected override void DeleteCore(T entity)
        //{
        //    //Table.Delete().Delete(entity).Execute();
        //}

        ///// <summary>
        ///// Deletes all the <typeparamref name="T"/> entities from the backing database or collection.
        ///// </summary>
        ///// <param name="entities">The entities to delete.</param>
        //protected override void DeleteCore(IEnumerable<T> entities)
        //{
        //    foreach (var entity in entities)
        //    {
        //        DeleteCore(entity);
        //    }
        //}

        ///// <summary>
        ///// Updates the <typeparamref name="T"/> entity in the backing database or collection.
        ///// </summary>
        ///// <param name="entity">The entity to update.</param>
        //protected override void UpdateCore(T entity)
        //{
        //    Table.Select(e => entity).Update().Execute();
        //}

        ///// <summary>
        ///// Updates all the <typeparamref name="T"/> entities in the backing database or collection.
        ///// </summary>
        ///// <param name="entities">The entities to update.</param>
        //protected override void UpdateCore(IEnumerable<T> entities)
        //{
        //    foreach (var entity in entities)
        //    {
        //        UpdateCore(entity);
        //    }
        //}
    }

    ///// <summary>
    ///// 
    ///// </summary>
    //public class CassandraQueryContext : QueryContext<ISession>
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="provider"></param>
    //    /// <param name="session"></param>
    //    public CassandraQueryContext(IServiceProvider provider, ISession session) : base(provider)
    //    {
    //    }

    //    /// <summary>
    //    /// Creates a query for the given <typeparamref name="T"/> model representing a table or collection.
    //    /// </summary>
    //    /// <typeparam name="T">The type representing the table or collection.</typeparam>
    //    /// <param name="name">Optional, parameter is only used in some implementations of the <see cref="IQueryContext"/></param>
    //    /// <returns></returns>
    //    public override IQuery<T> Query<T>(string name = null)
    //    {
    //        return new CassandraQuery<T>(new Table<T>(Context), this);
    //    }

    //    /// <summary>
    //    /// Will evaluate the <paramref name="expression"/> if <see cref="QueryContext.SuppressCompatibilityErrors"/> is false.
    //    /// </summary>
    //    /// <param name="expression"></param>
    //    protected override void EvaluateExpression(Expression expression)
    //    {
    //    }
    //}
}
