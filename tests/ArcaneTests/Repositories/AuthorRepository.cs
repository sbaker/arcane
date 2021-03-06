﻿using System.Collections.Generic;
using System.Linq;
using Arcane;
using ArcaneTests.Models;

namespace ArcaneTests.Repositories
{
    internal class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(IQueryContext context) : base(context)
        {
        }

        public IEnumerable<Author> GetAuthorsByFirstName(string name)
        {
            return Context.Query<Author>()
                .Where(a => a.Name.StartsWith(name));
        }

        public IEnumerable<Author> GetMostRecent10Authors()
        {
            return Context.Query<Author>()
                .OrderByDescending(a => a.CreatedDate)
                .Take(10);
        }
    }
}
