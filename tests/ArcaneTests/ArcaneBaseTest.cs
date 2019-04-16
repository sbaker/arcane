using Arcane;
using ArcaneTests.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ArcaneTests.Repositories;

namespace ArcaneTests
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public abstract class ArcaneBaseTest
    {
        protected const int Total = 100;
        protected static readonly DateTime Date = new DateTime(2016, 6, 30, 0, 0, 0, DateTimeKind.Utc);

        protected ArcaneBaseTest(IServiceProviderFactory providerFactory)
        {
            var provider = providerFactory.CreateServiceProvider();
            Provider = provider;
            Context = (IQueryContext)provider.GetService(typeof(IQueryContext));
        }

        protected IServiceProvider Provider { get; }
        
        protected IQueryContext Context { get; }

        protected IRepository Repository => new Repository(Context);

        protected IAuthorRepository AuthorRepository => new AuthorRepository(Context);

        protected static Author[] GetAuthors(int? total = null)
        {
            if (total == null)
            {
                total = Total;
            }

            var results = new List<Author>();

            for (int i = 1; i <= total; i++)
            {
                results.Add(new Author
                {
                    Id = i,
                    Name = $"First{i} Last{i}",
                    CreatedDate = Date.AddDays(-(Total + i)),
                    Books = new Collection<Book> {
                        new Book {
                            Id = i,
                            Name = $"C# Development\nBook #{i} of {Total}",
                            PublishDate = Date.AddMonths(-(Total - i))
                        }
                    }
                });
            }

            return results.ToArray();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IServiceProviderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IServiceProvider CreateServiceProvider();
    }
}
