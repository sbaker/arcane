using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcaneTests.DocumentDB
{
    internal class DocumentClientHelper
    {
        /// <summary>
        /// Create a DocumentCollection, and retries if throttled.
        /// </summary>
        /// <param name="client">The DocumentDB client instance.</param>
        /// <param name="database">The database to use.</param>
        /// <param name="collectionDefinition">The collection definition to use.</param>
        /// <param name="offerThroughput">The offer throughput for the collection.</param>
        /// <returns>The created DocumentCollection.</returns>
        public static async Task<DocumentCollection> CreateDocumentCollectionWithRetriesAsync(
            DocumentClient client,
            string databaseId,
            DocumentCollection collectionDefinition,
            int? offerThroughput = 400)
        {
            return await ExecuteWithRetries(
                client,
                () => client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(databaseId),
                        collectionDefinition,
                        new RequestOptions { OfferThroughput = offerThroughput }));
        }

        /// <summary>
        /// Execute the function with retries on throttle.
        /// </summary>
        /// <typeparam name="V">The type of return value from the execution.</typeparam>
        /// <param name="client">The DocumentDB client instance.</param>
        /// <param name="function">The function to execute.</param>
        /// <returns>The response from the execution.</returns>
        public static async Task<V> ExecuteWithRetries<V>(DocumentClient client, Func<Task<V>> function)
        {
            TimeSpan sleepTime = TimeSpan.Zero;

            while (true)
            {
                try
                {
                    return await function();
                }
                catch (DocumentClientException de)
                {
                    if ((int)de.StatusCode != 429 && (int)de.StatusCode != 449)
                    {
                        throw;
                    }

                    sleepTime = de.RetryAfter;
                }
                catch (AggregateException ae)
                {
                    if (!(ae.InnerException is DocumentClientException))
                    {
                        throw;
                    }

                    DocumentClientException de = (DocumentClientException)ae.InnerException;
                    if ((int)de.StatusCode != 429)
                    {
                        throw;
                    }

                    sleepTime = de.RetryAfter;
                    if (sleepTime < TimeSpan.FromMilliseconds(10))
                    {
                        sleepTime = TimeSpan.FromMilliseconds(10);
                    }
                }

                await Task.Delay(sleepTime);
            }
        }

    }
}
