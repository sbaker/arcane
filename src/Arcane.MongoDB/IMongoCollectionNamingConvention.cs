using System;

namespace Arcane.MongoDB
{
    /// <summary>
    /// Provides a convention for collection names to be created when accessing data.
    /// </summary>
    public interface IMongoCollectionNamingConvention
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        string GetNameFor<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectionType"></param>
        /// <returns></returns>
        string GetNameForType(Type collectionType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        string GetPluralName(string collectionName);
    }
}