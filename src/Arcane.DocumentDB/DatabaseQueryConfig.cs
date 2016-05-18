using System;
using System.Linq;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace Arcane.DocumentDB
{
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

        protected ICollectionIdProvider Provider { get; }

        public DocumentClient Client { get; set; }

        public Database Database { get; set; }

        /// <summary>
        /// The <see cref="FeedOptions"/> to pass along for the current requests.
        /// </summary>
        public FeedOptions FeedOptions { get; set; }

        protected virtual Uri GetId<T>()
        {
            return Provider.GetId<T>(Database.Id);
        }

        internal IQueryable<T> CreateDocumentQuery<T>()
        {
            return CreateDocumentQuery<T>(GetId<T>(), FeedOptions);
        }

        internal IQueryable<T> CreateDocumentQuery<T>(Uri documentUri, FeedOptions feedOptions = null)
        {
            return Client.CreateDocumentQuery<T>(documentUri, feedOptions);
        }
    }
}