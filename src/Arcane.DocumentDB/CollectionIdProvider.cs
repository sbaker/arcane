using System;
using System.Threading;

namespace Arcane.DocumentDB
{
    public abstract class CollectionIdProvider : ICollectionIdProvider
    {
        private static ICollectionIdProvider _instance = new TypeNameCollectionIdProvider();

        public static ICollectionIdProvider Default => _instance;

        public static void SetDefaultFactory(ICollectionIdProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            Interlocked.Exchange(ref _instance, provider);
        }

        public abstract Uri GetId<T>(string databaseId);
    }
}