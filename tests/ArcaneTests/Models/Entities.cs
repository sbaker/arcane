using System;
using System.Collections.ObjectModel;

namespace ArcaneTests.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Collection<Book> Books { get; set; }
    }

    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
