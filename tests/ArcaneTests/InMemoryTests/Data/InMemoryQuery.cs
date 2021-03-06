﻿using System.Collections.Generic;
using System.Linq;
using Arcane;

namespace ArcaneTests.InMemoryTests.Data
{
    internal class InMemoryQuery<T> : Query<T>
    {
        public InMemoryQuery(IList<T> list, IQueryContext context) : base(list.AsQueryable(), context)
        {
            List = list;
        }
        
        private IList<T> List { get; }

        //protected override void AddCore(T entity)
        //{
        //    List.Add(entity);
        //}

        //protected override void AddCore(IEnumerable<T> entities)
        //{
        //    foreach (var entity in entities)
        //    {
        //        AddCore(entity);
        //    }
        //}

        //protected override void DeleteCore(T entity)
        //{
        //    List.Remove(entity);
        //}

        //protected override void DeleteCore(IEnumerable<T> entities)
        //{
        //    foreach (var entity in entities)
        //    {
        //        DeleteCore(entity);
        //    }
        //}

        //protected override void UpdateCore(T entity)
        //{
        //    if (!List.Contains(entity))
        //    {
        //        AddCore(entity);
        //    }
        //}

        //protected override void UpdateCore(IEnumerable<T> entities)
        //{
        //    foreach (var entity in entities)
        //    {
        //        if (!List.Contains(entity))
        //        {
        //            AddCore(entity);
        //        }
        //    }
        //}
    }
}
