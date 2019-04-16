using System;
using System.Linq;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace Arcane.DocumentDB
{
    /// <summary>
    /// 
    /// </summary>
    public class DatabaseQueryConfig
    {
        /// <summary>
        /// Creates an instance of this class using the default <see cref="CollectionIdProvider.Default"/>.
        /// </summary>
        public DatabaseQueryConfig() : this(CollectionIdProvider.Default)
        {
        }

        /// <summary>
        /// Creates an instance of this class using the specified <paramref name="provider"/>.
        /// </summary>
        public DatabaseQueryConfig(ICollectionIdProvider provider)
        {
            Provider = provider;
        }

        /// <summary>
        /// 
        /// </summary>
        protected ICollectionIdProvider Provider { get; }

        /// <summary>
        /// 
        /// </summary>
        public DocumentClient Client { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Database Database { get; set; }

        /// <summary>
        /// The <see cref="FeedOptions"/> to pass along for the current requests.
        /// </summary>
        public FeedOptions FeedOptions { get; set; }

        /// <summary>
        /// The <see cref="RequestOptions"/> to pass along for the current requests.
        /// </summary>
        public RequestOptions RequestOptions { get; set; }

        /// <summary>
        /// The <see cref="FeedOptions"/> to pass along for the current requests.
        /// </summary>
        public bool EnableAutoIdGeneration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        protected virtual Uri GetId<T>(string name = null)
        {
            return Provider.GetId<T>(Database.Id, name);
        }

        internal IQueryable<T> CreateDocumentQuery<T>(string name = null)
        {
            return CreateDocumentQuery<T>(GetId<T>(), FeedOptions);
        }
        
        internal IQueryable<T> CreateDocumentQuery<T>(Uri documentUri, FeedOptions feedOptions = null)
        {
            return Client.CreateDocumentQuery<T>(documentUri.OriginalString, feedOptions);
        }

        internal T CreateDocument<T>(T document)
        {
            Client.CreateDocumentAsync(GetId<T>().OriginalString, document, RequestOptions, EnableAutoIdGeneration).Wait();
            return document;
        }

        internal void DeleteDocument<T>(T document)
        {
            throw new NotImplementedException();
            //Client.DeleteDocumentAsync("").Wait();
        }

        internal void UpdateDocument<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}