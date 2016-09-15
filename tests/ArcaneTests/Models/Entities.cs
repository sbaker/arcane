using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ArcaneTests.Models
{
    internal interface IRootEntity<T> where T : struct
    {
        T Id { get; set; }
    }

    internal class Author : IRootEntity<int>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        public string Name { get; set; }

        public Collection<Book> Books { get; set; }

        public DateTime CreatedDate { get; set; }
    }

    internal class Book : IRootEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
