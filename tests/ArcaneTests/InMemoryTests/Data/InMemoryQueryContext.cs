//using Arcane;
//using ArcaneTests.Models;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;

//namespace ArcaneTests.InMemoryTests.Data
//{
    //internal class InMemoryQueryContext : QueryContext
    //{
    //    private readonly List<Author> _authors = new List<Author>();

    //    public InMemoryQueryContext(IEnumerable<Author> authors)
    //    {
    //        _authors.AddRange(authors);
    //    }

    //    public override IQuery<T> Query<T>(string name = null)
    //    {
    //        var type = typeof(T);

    //        if (type == typeof(Author))
    //        {
    //            return new InMemoryQuery<T>(_authors.Cast<T>().ToList(), this);
    //        }

    //        if (type == typeof(Book))
    //        {
    //            return new InMemoryQuery<T>(_authors.SelectMany(a => a.Books).Cast<T>().ToList(), this);
    //        }

    //        return new InMemoryQuery<T>(Enumerable.Empty<T>().ToList(), this);
    //    }

    //    protected override void EvaluateExpression(Expression expression)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    protected override void DisposeCore(bool disposing)
    //    {
    //    }
    //}
//}
