using Arcane;
using ArcaneTests.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ArcaneTests
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class ArcaneBaseTest
    {
        protected const int Total = 100;
        protected static readonly DateTime Date = new DateTime(2016, 6, 30, 0, 0, 0, DateTimeKind.Utc);
        
        protected IQueryContext Context { get; set; }

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
}
