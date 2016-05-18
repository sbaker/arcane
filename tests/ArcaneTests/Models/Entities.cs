using System;
using System.Collections.ObjectModel;

namespace ArcaneTests.Models
{
    public interface IRootEntity<T> where T : struct
    {
        T Id { get; set; }
    }

    public class Author : IRootEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Collection<Book> Books { get; set; }

        public DateTime CreatedDate { get; set; }
    }

    public class Book : IRootEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
