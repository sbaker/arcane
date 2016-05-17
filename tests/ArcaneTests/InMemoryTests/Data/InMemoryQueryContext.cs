using Arcane;
using ArcaneTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcaneTests.InMemoryTests.Data
{
    public class InMemoryQueryContext : QueryContext
    {
        private List<Author> _authors = new List<Author>();

        public InMemoryQueryContext(Author[] authors)
        {
            _authors.AddRange(authors);
        }

        public override IQuery<T> Query<T>()
        {
            var type = typeof(T);

            if (type == typeof(Author))
            {
                return new Query<T>(_authors.Cast<T>().AsQueryable());
            }

            if (type == typeof(Book))
            {
                return new Query<T>(_authors.SelectMany(a => a.Books).Cast<T>().AsQueryable());
            }
            
            return new Query<T>(Enumerable.Empty<T>().AsQueryable());
        }

        public override void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public override Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        protected override void DisposeCore(bool disposing)
        {
        }
    }
}
