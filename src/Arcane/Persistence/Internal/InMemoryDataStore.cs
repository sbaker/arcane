using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Arcane.Persistence.Internal
{
    internal class InMemoryDataStore : IDataStore
    {
        private static readonly IDictionary<Type, ICollection<object>> BackingStore = new ConcurrentDictionary<Type, ICollection<object>>();
        private static readonly object SyncRoot = new object();

        private readonly ConcurrentBag<object> _inserted = new ConcurrentBag<object>();
        private readonly ConcurrentBag<object> _updated = new ConcurrentBag<object>();
        private readonly ConcurrentBag<object> _deleted = new ConcurrentBag<object>();

        internal static IQueryable<T> GetInMemoryData<T>()
        {
            lock (SyncRoot)
            {
                var type = typeof(T);

                if (!BackingStore.ContainsKey(type))
                {
                    BackingStore[type] = new List<object>();
                }

                return BackingStore[type].Cast<T>().AsQueryable();
            }
        }

        /// <summary>
        /// Calls to the wrapped implementation to persist the changes made.
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            var total = 0;

            if (_inserted.Count > 0)
            {
                total += _inserted.Count;
                InsertCollection(_inserted);
            }

            if (_updated.Count > 0)
            {
                total += _updated.Count;
                InsertCollection(_updated);
            }

            if (_deleted.Count > 0)
            {
                total += _deleted.Count;
                DeleteCollection(_deleted);
            }
            
            return total;
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Insert<T>(T entity) where T : class, IFindable<T>
        {
            _inserted.Add(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Update<T>(T entity) where T : class, IFindable<T>
        {
            _updated.Add(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Delete<T>(T entity) where T : class, IFindable<T>
        {
            _deleted.Add(entity);
        }

        private static void DeleteCollection(IEnumerable<object> collection)
        {
            lock (SyncRoot)
            {
                foreach (var item in collection)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    var type = item.GetType();

                    if (!BackingStore.ContainsKey(type))
                    {
                        BackingStore[type] = new List<object>();
                    }

                    if (BackingStore[type].Contains(item))
                    {
                        BackingStore[type].Remove(item);
                    }
                }
            }
        }

        private static void InsertCollection(IEnumerable<object> collection)
        {
            lock (SyncRoot)
            {
                foreach (var item in collection)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    var type = item.GetType();

                    if (!BackingStore.ContainsKey(type))
                    {
                        BackingStore[type] = new List<object>();
                    }

                    if (!BackingStore[type].Contains(item))
                    {
                        BackingStore[type].Add(item);
                    }
                }
            }
        }
    }
}