using System;

namespace Arcane.DocumentDB
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICollectionIdProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="databaseId"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        Uri GetId<T>(string databaseId, string collectionName = null);
    }
}