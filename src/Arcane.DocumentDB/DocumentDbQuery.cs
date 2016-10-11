using System.Collections.Generic;
using System.Linq;

namespace Arcane.DocumentDB
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DocumentDbQuery<T> : Query<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="innerQuery"></param>
        /// <param name="context"></param>
        /// <param name="config"></param>
        public DocumentDbQuery(IQueryable<T> innerQuery, IQueryContext context, DatabaseQueryConfig config) : base(innerQuery, context)
        {
            Config = config;
        }

        /// <summary>
        /// 
        /// </summary>
        public DatabaseQueryConfig Config { get; }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="entity"></param>
        //protected override void AddCore(T entity)
        //{
        //    Config.CreateDocument(entity);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="entities"></param>
        //protected override void AddCore(IEnumerable<T> entities)
        //{
        //    foreach (var entity in entities)
        //    {
        //        AddCore(entity);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="entity"></param>
        //protected override void DeleteCore(T entity)
        //{
        //    Config.DeleteDocument(entity);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="entities"></param>
        //protected override void DeleteCore(IEnumerable<T> entities)
        //{
        //    foreach (var entity in entities)
        //    {
        //        DeleteCore(entity);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="entity"></param>
        //protected override void UpdateCore(T entity)
        //{
        //    Config.UpdateDocument(entity);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="entities"></param>
        //protected override void UpdateCore(IEnumerable<T> entities)
        //{
        //    foreach (var entity in entities)
        //    {
        //        UpdateCore(entity);
        //    }
        //}
    }
}
