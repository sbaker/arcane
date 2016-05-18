using System;
using Microsoft.Azure.Documents.Client;

namespace Arcane.DocumentDB
{
    public class TypeNameCollectionIdProvider : CollectionIdProvider
    {
        public override Uri GetId<T>(string databaseId)
        {
            return UriFactory.CreateDocumentCollectionUri(databaseId, typeof(T).Name);
        }
    }
}