using System;
using Microsoft.Azure.Documents.Client;

namespace Arcane.DocumentDB
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TypeNameCollectionIdProvider : CollectionIdProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="databaseId"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public override Uri GetId<T>(string databaseId, string collectionName = null)
        {
            return UriFactory.CreateDocumentCollectionUri(databaseId, collectionName ?? $"{typeof(T).Name}s");
        }
    }
}