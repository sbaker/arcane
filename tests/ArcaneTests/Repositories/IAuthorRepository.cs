using System.Collections.Generic;
using ArcaneTests.Models;

namespace ArcaneTests.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAuthorsByFirstName(string name);

        IEnumerable<Author> GetMostRecent10Authors();

        void Add(Author author);
    }
}