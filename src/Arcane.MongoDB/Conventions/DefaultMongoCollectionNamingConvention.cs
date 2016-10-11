using System;

namespace Arcane.MongoDB.Conventions
{
    internal class DefaultMongoCollectionNamingConvention : IMongoCollectionNamingConvention
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public string GetNameFor<T>()
        {
            return GetNameForType(typeof(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectionType"></param>
        /// <returns></returns>
        public string GetNameForType(Type collectionType)
        {
            return GetPluralName(collectionType.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public string GetPluralName(string collectionName)
        {
            return $"{collectionName}s";
        }
    }
}