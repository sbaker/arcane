using Arcane;
using ArcaneTests.Models;
using System.Collections.Generic;
using System.Linq;

namespace ArcaneTests.InMemoryTests.Data
{
    public class InMemoryQueryContext : QueryContext
    {
        private List<Author> _authors = new List<Author>();

        public InMemoryQueryContext(Author[] authors)
        {
            _authors.AddRange(authors);
        }

        protected override IQueryable<T> CreateQueryable<T>(string name = null)
        {
            var type = typeof(T);

            if (type == typeof(Author))
            {
                return _authors.Cast<T>().AsQueryable();
            }

            if (type == typeof(Book))
            {
                return _authors.SelectMany(a => a.Books).Cast<T>().AsQueryable();
            }
            
            return Enumerable.Empty<T>().AsQueryable();
        }

        protected override void DisposeCore(bool disposing)
        {
        }
    }
}
