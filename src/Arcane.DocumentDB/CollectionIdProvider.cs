using System;
using System.Threading;

namespace Arcane.DocumentDB
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class CollectionIdProvider : ICollectionIdProvider
    {
        private static ICollectionIdProvider _instance = new TypeNameCollectionIdProvider();

        /// <summary>
        /// 
        /// </summary>
        public static ICollectionIdProvider Default => _instance;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        public static void SetDefaultFactory(ICollectionIdProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            Interlocked.Exchange(ref _instance, provider);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="databaseId"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public abstract Uri GetId<T>(string databaseId, string collectionName = null);
    }
}