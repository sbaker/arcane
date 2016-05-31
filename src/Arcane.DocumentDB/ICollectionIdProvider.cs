using System;

namespace Arcane.DocumentDB
{
    public interface ICollectionIdProvider
    {
        Uri GetId<T>(string databaseId, string collectionName = null);
    }
}