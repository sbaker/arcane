using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Arcane.Data;
using Newtonsoft.Json;

namespace ArcaneTests.Models
{
    internal interface IRootEntity<T> where T : struct
    {
        T Id { get; set; }
    }

    internal class Author : IRootEntity<int>, IFindable<Author>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        public string Name { get; set; }

        public Collection<Book> Books { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public Expression<Func<Author, bool>> GetExpression()
        {
            return a => a.Id == Id;
        }
    }

    internal class Book : IRootEntity<int>, IFindable<Book>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime PublishDate { get; set; }
        
        public Expression<Func<Book, bool>> GetExpression()
        {
            return a => a.Id == Id;
        }
    }
}
