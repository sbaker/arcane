using System;
using Microsoft.Azure.Documents.Client;

namespace Arcane.DocumentDB
{
    public sealed class TypeNameCollectionIdProvider : CollectionIdProvider
    {
        public override Uri GetId<T>(string databaseId, string collectionName = null)
        {
            return UriFactory.CreateDocumentCollectionUri(databaseId, collectionName ?? $"{typeof(T).Name}s");
        }
    }
}